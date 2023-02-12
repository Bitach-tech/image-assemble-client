﻿using Global.ApplicationProxies.Runtime;
using Global.Audio.Player.Runtime;
using Global.Cameras.CameraUtilities.Runtime;
using Global.Cameras.CurrentCameras.Runtime;
using Global.Cameras.GlobalCameras.Runtime;
using Global.Debugs.Console.Runtime;
using Global.Inputs.View.Runtime;
using Global.Loggers.Runtime;
using Global.MessageBrokers.Runtime;
using Global.Publisher.Bootstrap;
using Global.ResourcesCleaners.Runtime;
using Global.Scenes.CurrentSceneHandlers.Runtime;
using Global.Scenes.ScenesFlow.Runtime;
using Global.Setup.Abstract;
using Global.Setup.Service;
using Global.UI.LoadingScreens.Runtime;
using Global.UI.Overlays.Runtime;
using Global.UI.UiStateMachines.Runtime;
using Global.Updaters.Runtime;
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

        public override IGlobalServiceFactory[] GetFactories()
        {
            return new IGlobalServiceFactory[]
            {
                _applicationProxy,
                _cameraUtils,
                _currentCamera,
                _currentSceneHandler,
                _globalCamera,
                _inputView,
                _logger,
                _resourcesCleaner,
                _scenesFlow,
                _updater,
                _debugConsole,
                _messageBroker,
                _uiStateMachine,
                _soundsPlayer,
                _publisherSdk
            };
        }

        public override IGlobalServiceAsyncFactory[] GetAsyncFactories()
        {
            return new IGlobalServiceAsyncFactory[]
            {
                _loadingScreen,
                _overlay
            };
        }
    }
}