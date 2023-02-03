using GamePlay.Level.ImageStorage.Runtime;
using GamePlay.Loop.Difficulties;

namespace GamePlay.Level.Assemble.Runtime
{
    public interface IAssembler
    {
        void Begin(LevelImage[] images, LevelDifficulty difficulty);

        void Stop();
    }
}