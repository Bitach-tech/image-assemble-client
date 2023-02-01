using GamePlay.Level.ImageStorage.Runtime;

namespace GamePlay.Level.Assemble.Runtime
{
    public interface IPuzzleAssembler
    {
        void AssemblePreview(LevelImage image);
        void AssembleCurrent();
        void Begin();
        void Cancel();
    }
}