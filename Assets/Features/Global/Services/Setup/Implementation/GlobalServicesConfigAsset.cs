using Global.Audio.Player.Runtime;
using Global.Cameras.CameraUtilities.Runtime;
using Global.Cameras.CurrentCameras.Runtime;
using Global.Cameras.GlobalCameras.Runtime;
using Global.Debug.Console.Runtime;
using Global.Inputs.View.Runtime;
using Global.Publisher.Bootstrap;
using Global.Scenes.CurrentSceneHandlers.Runtime;
using Global.Scenes.ScenesFlow.Runtime;
using Global.Setup.Abstract;
using Global.Setup.Service;
using Global.System.ApplicationProxies.Runtime;
using Global.System.Loggers.Runtime;
using Global.System.MessageBrokers.Runtime;
using Global.System.ResourcesCleaners.Runtime;
using Global.System.Updaters.Runtime;
using Global.UI.LoadingScreens.Runtime;
using Global.UI.Overlays.Runtime;
using Global.UI.UiStateMachines.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Setup.Implementation
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "GlobalConfig",
        menuName = "Global/Config")]
    public class GlobalServicesConfigAsset : GlobalServicesConfig
    {
        [SerializeField] private ApplicationProxyAsset _applicationProxy;
        [SerializeField] private CameraUtilsAsset _cameraUtils;
        [SerializeField] private CurrentCameraAsset _currentCamera;
        [SerializeField] private CurrentSceneHandlerAsset _currentSceneHandler;
        [SerializeField] private GlobalCameraAsset _globalCamera;
        [SerializeField] private InputViewAsset _inputView;
        [SerializeField] private LoadingScreenAsset _loadingScreen;
        [SerializeField] private LoggerAsset _logger;
        [SerializeField] private ResourcesCleanerAsset _resourcesCleaner;
        [SerializeField] private ScenesFlowAsset _scenesFlow;
        [SerializeField] private UpdaterAsset _updater;
        [SerializeField] private DebugConsoleAsset _debugConsole;
        [SerializeField] private MessageBrokerAsset _messageBroker;
        [SerializeField] private UiStateMachineAsset _uiStateMachine;
        [SerializeField] private SoundsPlayerAsset _soundsPlayer;
        [SerializeField] private OverlayAsset _overlay;
        [SerializeField] private PublisherSdkAsset _publisherSdk;

        public override GlobalServiceAsset[] GetAssets()
        {
            return new GlobalServiceAsset[]
            {
                _applicationProxy,
                _cameraUtils,
                _currentCamera,
                _currentSceneHandler,
                _globalCamera,
                _inputView,
                _loadingScreen,
                _logger,
                _resourcesCleaner,
                _scenesFlow,
                _updater,
                _debugConsole,
                _messageBroker,
                _uiStateMachine,
                _soundsPlayer,
                _overlay,
                _publisherSdk
            };
        }
    }
}