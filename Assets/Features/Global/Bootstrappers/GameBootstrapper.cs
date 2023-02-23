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
            Debug.Log("Bootstrapper awake");
            
            SceneManager.sceneLoaded += OnSceneLoaded;

            SceneManager.LoadScene(_servicesScene, LoadSceneMode.Additive);
            Debug.Log("Bootstrapper 0");

            void OnSceneLoaded(Scene scene, LoadSceneMode mode)
            {
                SceneManager.sceneLoaded -= OnSceneLoaded;

                Debug.Log("Bootstrapper 1");

                Bootstrap(scene).Forget();
            }
        }

        private async UniTaskVoid Bootstrap(Scene servicesScene)
        {
            Debug.Log("Bootstrapper 2");

            var binder = new GlobalServiceBinder(servicesScene);
            var sceneLoader = new GlobalSceneLoader();
            var callbacks = new GlobalCallbacks();
            var dependencyRegister = new ContainerBuilder();
            
            Debug.Log("Bootstrapper 3");


            var gameLoop = _gameLoop.Create(dependencyRegister, binder);
            
            Debug.Log("Bootstrapper 4");


            var factories = _services.GetFactories();
            var asyncFactories = _services.GetAsyncFactories();
            
            Debug.Log("Bootstrapper 5");


            var factoryWatch = new Stopwatch();
            factoryWatch.Start();

            foreach (var factory in factories)
                factory.Create(dependencyRegister, binder, callbacks);
            
            Debug.Log("Bootstrapper 6");


            var asyncFactoriesTasks = new UniTask[asyncFactories.Length];

            for (var i = 0; i < asyncFactories.Length; i++)
                asyncFactoriesTasks[i] = asyncFactories[i].Create(dependencyRegister, binder, sceneLoader, callbacks);

            await UniTask.WhenAll(asyncFactoriesTasks);
            
            Debug.Log("Bootstrapper 7");


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
            
            Debug.Log("Bootstrapper 8");

            dependencyRegister.ResolveAllWithCallbacks(scope.Container, callbacks);
            Debug.Log("Bootstrapper 9");

            await callbacks.InvokeFlowCallbacks();
            Debug.Log("Bootstrapper 10");

            gameLoop.OnAwake();
            Debug.Log("Bootstrapper 11");

            gameLoop.Begin();
            
            Debug.Log("Bootstrapper 11");
        }
    }
}