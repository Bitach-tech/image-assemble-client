using Features.GamePlay.Level.ImageStorage.Runtime;

namespace Features.GamePlay.Level.Assemble.Runtime
{
    public readonly struct AssembledEvent
    {
        public AssembledEvent(LevelImage image)
        {
            Image = image;
        }

        public readonly LevelImage Image;
    }
}