using Cysharp.Threading.Tasks;
using Features.Common.Local.ComposedSceneConfig;
using Features.GamePlay.Config.Services.Runtime;
using Features.Global.GameLoops.Abstract;
using Features.Global.GameLoops.Logs;
using Features.Global.Services.Common.Scope;
using Features.Global.Services.CurrentCameras.Runtime;
using Features.Global.Services.CurrentSceneHandlers.Runtime;
using Features.Global.Services.GlobalCameras.Runtime;
using Features.Global.Services.LoadingScreens.Runtime;
using Features.Global.Services.ScenesFlow.Runtime.Abstract;
using UnityEngine;
using VContainer;

namespace Features.Global.GameLoops.Runtime
{
    public class GameLoop : GlobalGameLoop
    {
        [Inject]
        private void Construct(
            GlobalScope scope,
            ISceneLoader loader,
            ILoadingScreen loadingScreen,
            IGlobalCamera globalCamera,
            ICurrentSceneHandler currentSceneHandler,
            ICurrentCamera currentCamera,
            GameLoopLogger logger)
        {
            _logger = logger;
            _scope = scope;
            _loader = loader;
            _loadingScreen = loadingScreen;
            _globalCamera = globalCamera;
            _currentSceneHandler = currentSceneHandler;
            _currentCamera = currentCamera;
        }

        [SerializeField] private GameAsset _game;

        private ICurrentCamera _currentCamera;
        private ICurrentSceneHandler _currentSceneHandler;
        private IGlobalCamera _globalCamera;

        private ISceneLoader _loader;
        private ILoadingScreen _loadingScreen;

        private GameLoopLogger _logger;

        private GlobalScope _scope;

        public override void OnAwake()
        {
        }

        public override void Begin()
        {
            _logger.OnLoadLevel();
            Debug.Log(1);
            LoadScene(_game).Forget();
        }

        private async UniTaskVoid LoadScene(ComposedSceneAsset asset)
        {
            _globalCamera.Enable();
            _currentCamera.SetCamera(_globalCamera.Camera);

            _loadingScreen.Show();

            var unload = _currentSceneHandler.Unload();
            var result = await asset.Load(_scope, _loader);

            await unload;
            await _currentSceneHandler.FinalizeUnloading();

            _currentSceneHandler.OnLoaded(result);
            _globalCamera.Disable();
            _loadingScreen.Hide();

            result.OnLoaded();
        }
    }
}