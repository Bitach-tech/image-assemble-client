using System;
using GamePlay.Services.Overlays.SoundSwitches.Runtime;
using Global.Services.Setup.Abstract;
using Global.Services.System.MessageBrokers.Runtime;
using UnityEngine;

namespace Global.Services.Audio.SoundsPlayers.Runtime
{
    [DisallowMultipleComponent]
    public class SoundsVolumeSwitcher : MonoBehaviour, IGlobalAwakeListener
    {
        [SerializeField] private float _defaultMusicVolume = 0.1f;
        [SerializeField] private float _defaultSoundVolume = 0.01f;

        [SerializeField] private SoundsPlayer _player;

        private bool _isMuted = false;

        private IDisposable _soundSwitchListener;

        public void OnDestroy()
        {
            _soundSwitchListener?.Dispose();
        }

        public void OnAwake()
        {
            _soundSwitchListener = Msg.Listen<SoundSwitchClickEvent>(OnSoundSwitchedClicked);
        }

        private void OnSoundSwitchedClicked(SoundSwitchClickEvent data)
        {
            _isMuted = !_isMuted;

            if (_isMuted == true)
                _player.SetVolume(0f, 0f);
            else
                _player.SetVolume(_defaultMusicVolume, _defaultSoundVolume);
        }
    }
}