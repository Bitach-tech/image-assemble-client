﻿using System;
using GamePlay.Overlays.SoundSwitches.Runtime;
using Global.Publisher.Abstract.DataStorages;
using Global.Publisher.Abstract.Saves;
using Global.Setup.Service.Callbacks;
using Global.System.MessageBrokers.Runtime;
using UnityEngine;
using VContainer;

namespace Global.Audio.Player.Runtime
{
    [DisallowMultipleComponent]
    public class SoundsVolumeSwitcher : MonoBehaviour, IGlobalBootstrapListener
    {   
        [Inject]
        private void Construct(IDataStorage storage)
        {
            _storage = storage;
        }
            
        [SerializeField] private SoundsPlayer _player;
        [SerializeField] private SoundState _state;
        
        private IDataStorage _storage;
        private SoundSave _save;
        
        private IDisposable _soundSwitchListener;
        
        public void OnBootstrapped()
        {
            _soundSwitchListener = Msg.Listen<SoundSwitchEvent>(OnSoundSwitchedClicked);
            _save = _storage.GetEntry<SoundSave>(SavesPaths.Sounds);
            
            SetMute(_save.IsMuted);
        }
        
        private void OnDestroy()
        {
            _soundSwitchListener?.Dispose();
        }
            
        private void OnSoundSwitchedClicked(SoundSwitchEvent data)
        {
            _save.SwitchMute();
            SetMute(_save.IsMuted);
        }

        private void SetMute(bool isMuted)
        {
            if (isMuted == true)
            {
                _player.Mute();
                _state.OnMuted();
            }
            else
            {
                _player.Unmute();
                _state.OnUnmuted();
            }
        }
    }   
}       