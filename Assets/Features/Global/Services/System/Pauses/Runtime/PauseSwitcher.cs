using Global.Audio.Player.Runtime;
using Global.Updaters.Runtime.Abstract;

namespace Global.Pauses.Runtime
{
    public class PauseSwitcher : IPause
    {
        public PauseSwitcher(IUpdateSpeedSetter updateSpeedSetter, IVolumeSwitcher volumeSwitcher)
        {
            _updateSpeedSetter = updateSpeedSetter;
            _volumeSwitcher = volumeSwitcher;
        } 
        
        private readonly IUpdateSpeedSetter _updateSpeedSetter;
        private readonly IVolumeSwitcher _volumeSwitcher;
        
        public void Pause()
        {
            _updateSpeedSetter.Pause();
            _volumeSwitcher.Mute();
        }

        public void Continue()
        {
            _updateSpeedSetter.Continue();
            _volumeSwitcher.Unmute();
        }
    }
}