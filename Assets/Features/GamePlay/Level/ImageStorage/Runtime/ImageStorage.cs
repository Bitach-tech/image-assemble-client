using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GamePlay.Level.ImageStorage.Runtime
{
    public class ImageStorage : IImageStorage
    {
        public ImageStorage(LevelImage[] images)
        {
            _images = images;
        }

        private readonly LevelImage[] _images;

        public IReadOnlyList<LevelImage> GetImages()
        {
            return new ReadOnlyCollection<LevelImage>(_images);
        }
    }
}