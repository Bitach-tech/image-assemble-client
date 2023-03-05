using Global.Audio.Player.Runtime;
using Global.System.Updaters.Runtime.Abstract;

namespace Global.System.Pauses.Runtime
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