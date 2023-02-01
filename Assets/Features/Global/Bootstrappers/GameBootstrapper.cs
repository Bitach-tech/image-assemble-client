using System.Diagnostics;
using Cysharp.Threading.Tasks;
using Global.GameLoops.Runtime;
using Global.Setup.Abstract;
using Global.Setup.Scope;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;
using ContainerBuilder = Common.DiContainer.Runtime.ContainerBuilder;
using Debug = UnityEngine.Debug;

namespace Global.Bootstrappers
{
    [DisallowMultipleComponent]
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private GlobalScope _scope;
        [SerializeField] [Scene] private string _servicesScene;

        [SerializeField] private GameLoopAsset _gameLoop;
        [SerializeField] private GlobalServicesConfig _services;

        private void Awake()
        {
            var watch = new Stopwatch();
            watch.Start();
            
            SceneManager.sceneLoaded += OnSceneLoaded;

            SceneManager.LoadScene(_servicesScene, LoadSceneMode.Additive);

            void OnSceneLoaded(Scene scene, LoadSceneMode mode)
            {
                SceneManager.sceneLoaded -= OnSceneLoaded;

                Debug.Log($"Service scene loaded: {watch.ElapsedMilliseconds}");
                watch.Stop();
                
                Bootstrap(scene).Forget();
            }
        }

        private async UniTaskVoid Bootstrap(Scene servicesScene)
        {
            var watch = new Stopwatch();
            watch.Start();

            var binder = new GlobalServiceBinder(servicesScene);
            var sceneLoader = new GlobalSceneLoader();
            var callbacks = new GlobalCallbacks();
            var dependencyRegister = new ContainerBuilder();

            var services = _services.GetAssets();
            var servicesTasks = new UniTask[services.Length];
            
            Debug.Log($"Services assets received: {watch.ElapsedMilliseconds}");
            watch.Restart();

            var gameLoop = _gameLoop.Create(dependencyRegister, binder);

            for (var i = 0; i < servicesTasks.Length; i++)
                servicesTasks[i] = services[i].Create(dependencyRegister, binder, sceneLoader, callbacks);

            Debug.Log($"Tasks created: {watch.ElapsedMilliseconds}");
            watch.Restart();
            
            await UniTask.WhenAll(servicesTasks);
            
            Debug.Log($"Tasks awaited: {watch.ElapsedMilliseconds}");
            watch.Restart();

            var scope = Instantiate(_scope);
            scope.IsRoot = true;
            binder.AddToModules(scope);

            using (LifetimeScope.Enqueue(OnConfiguration))
            {
                await UniTask.Create(async () => scope.Build());
            }

            void OnConfiguration(IContainerBuilder builder)
            {
                dependencyRegister.RegisterAll(builder);
            }
            
            Debug.Log($"Container built: {watch.ElapsedMilliseconds}");
            watch.Restart();

            dependencyRegister.ResolveAllWithCallbacks(scope.Container, callbacks);

            await callbacks.InvokeFlowCallbacks();

            Debug.Log($"Callbacks invoked: {watch.ElapsedMilliseconds}");
            watch.Restart();
            
            gameLoop.OnAwake();

            gameLoop.Begin();
            
            Debug.Log($"Game loop started: {watch.ElapsedMilliseconds}");
            watch.Stop();
        }
    }
}