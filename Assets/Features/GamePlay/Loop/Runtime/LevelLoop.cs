using System;
using Common.Local.Services.Abstract.Callbacks;
using GamePlay.LevelCameras.Runtime;
using GamePlay.Loop.Events;
using GamePlay.Loop.Logs;
using GamePlay.Menu.Runtime;
using Global.Cameras.CurrentCameras.Runtime;
using Global.Publisher.Advertisement.Abstract;
using Global.System.MessageBrokers.Runtime;

namespace GamePlay.Loop.Runtime
{
    public class LevelLoop :
        ILocalLoadListener,
        ILocalSwitchListener
    {
        public LevelLoop(
            ICurrentCamera currentCamera,
            ILevelCamera levelCamera,
            IMenuUI menuUI,
            IAds ads,
            LevelLoopLogger logger)
        {
            _ads = ads;
            _menuUI = menuUI;
            _logger = logger;
            _currentCamera = currentCamera;
            _levelCamera = levelCamera;
        }

        private readonly IAds _ads;

        private readonly ICurrentCamera _currentCamera;
        private readonly ILevelCamera _levelCamera;

        private readonly LevelLoopLogger _logger;

        private readonly IMenuUI _menuUI;

        private IDisposable _playClickListener;
        private IDisposable _menuClickListener;

        public void OnLoaded()
        {
            _currentCamera.SetCamera(_levelCamera.Camera);

            _logger.OnLoaded();

            _menuUI.Open();
        }

        public void OnEnabled()
        {
            _playClickListener = Msg.Listen<PlayClickEvent>(OnPlayClicked);
            _menuClickListener = Msg.Listen<MenuRequestEvent>(OnMenuClicked);
        }

        public void OnDisabled()
        {
            _playClickListener?.Dispose();
            _menuClickListener?.Dispose();
        }

        private void OnPlayClicked(PlayClickEvent data)
        {
            _ads.ShowInterstitial();
        }

        private void OnMenuClicked(MenuRequestEvent data)
        {
            _menuUI.Open();
        }
    }
}