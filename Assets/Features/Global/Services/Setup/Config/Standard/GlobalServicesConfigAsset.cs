using Global.Common;
using Global.Services.Audio.SoundsPlayers.Runtime;
using Global.Services.Cameras.CameraUtilities.Runtime;
using Global.Services.Cameras.CurrentCameras.Runtime;
using Global.Services.Cameras.GlobalCameras.Runtime;
using Global.Services.Debug.DebugConsoles.Runtime;
using Global.Services.External.ServiceSDK.Bootstrap;
using Global.Services.Inputs.View.Runtime;
using Global.Services.Scenes.CurrentSceneHandlers.Runtime;
using Global.Services.Scenes.ScenesFlow.Runtime;
using Global.Services.Setup.Abstract;
using Global.Services.Setup.Config.Abstract;
using Global.Services.System.ApplicationProxies.Runtime;
using Global.Services.System.Loggers.Runtime;
using Global.Services.System.MessageBrokers.Runtime;
using Global.Services.System.ResourcesCleaners.Runtime;
using Global.Services.System.Updaters.Runtime;
using Global.Services.UI.LoadingScreens.Runtime;
using Global.Services.UI.Overlays.Runtime;
using Global.Services.UI.UiStateMachines.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.Setup.Config.Standard
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.BootstrapPrefix + "Services",
        menuName = GlobalAssetsPaths.BootstrapConfig)]
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
        [SerializeField] private ServiceSdkAsset _serviceSdk;

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
                _serviceSdk
            };
        }
    }
}