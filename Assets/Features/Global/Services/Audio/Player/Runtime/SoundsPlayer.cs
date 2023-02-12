using UnityEngine;

namespace Global.Audio.Player.Runtime
{
    [DisallowMultipleComponent]
    public class SoundsPlayer : MonoBehaviour, IVolumeSwitcher
    {
        [SerializeField] private AudioSource _musicSource;

        [SerializeField] private AudioSource[] _soundSources;

        private float _musicVolume;
        private float _soundVolume;

        public void Mute()
        {
            _musicVolume = _musicSource.volume;
            _soundVolume = _soundSources[0].volume;
            
            SetVolume(0f, 0f);
        }

        public void Unmute()
        {
            SetVolume(_musicVolume, _soundVolume);
        }
        
        public void SetVolume(float music, float sound)
        {
            _musicSource.volume = music;

            foreach (var source in _soundSources)
                source.volume = sound;
        }

        public void PlaySound(AudioClip clip)
        {
            foreach (var source in _soundSources)
            {
                if (source.isPlaying == true)
                    continue;

                source.clip = clip;
                source.Play();
            }

            _soundSources[0].clip = clip;
            _soundSources[0].Play();
        }

        public void PlayLoopMusic(AudioClip clip)
        {
            _musicSource.loop = true;
            _musicSource.clip = clip;
            _musicSource.Play();
        }
    }
}