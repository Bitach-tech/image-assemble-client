using Cysharp.Threading.Tasks;
using Features.Global.Services.ScenesFlow.Handling.Data;
using Features.Global.Services.ScenesFlow.Handling.Result;
using Features.Global.Services.ScenesFlow.Logs;
using Features.Global.Services.ScenesFlow.Runtime.Abstract;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

namespace Features.Global.Services.ScenesFlow.Runtime
{
    public class ScenesLoader : MonoBehaviour, ISceneLoader
    {
        [Inject]
        private void Construct(ScenesFlowLogger logger)
        {
            _logger = logger;
        }

        private ScenesFlowLogger _logger;

        public async UniTask<T> Load<T>(SceneLoadData<T> scene) where T : SceneLoadResult
        {
            var targetScene = new Scene();

            SceneManager.sceneLoaded += OnSceneLoaded;

            void OnSceneLoaded(Scene loadedScene, LoadSceneMode mode)
            {
                if (loadedScene.name != scene.Name)
                    return;

                targetScene = loadedScene;
                SceneManager.sceneLoaded -= OnSceneLoaded;
            }

            Debug.Log($"Load scene: {scene.Name}");

            var handle = SceneManager.LoadSceneAsync(scene.Name, LoadSceneMode.Additive);
            var task = handle.ToUniTask();
            await task;

            await UniTask.WaitUntil(() => targetScene.name == scene.Name);

            _logger.OnSceneLoad(targetScene);

            return scene.CreateLoadResult(targetScene);
        }
    }
}