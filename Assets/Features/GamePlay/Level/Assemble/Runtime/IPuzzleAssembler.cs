using Features.GamePlay.Level.ImageStorage.Runtime;

namespace Features.GamePlay.Level.Assemble.Runtime
{
    public interface IPuzzleAssembler
    {
        void AssemblePreview(LevelImage image);
        void AssembleCurrent();
        void Begin();
        void Cancel();
    }
}