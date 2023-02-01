using System.Collections.Generic;

namespace Features.GamePlay.Level.ImageStorage.Runtime
{
    public interface IImageStorage
    {
        IReadOnlyList<LevelImage> GetImages();
    }
}