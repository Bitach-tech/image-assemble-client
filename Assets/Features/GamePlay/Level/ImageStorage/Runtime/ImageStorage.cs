using System;
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

        public IReadOnlyList<LevelImage> GetShuffledImages()
        {
            var list = new List<LevelImage>(_images);
            Shuffle(list);

            return new ReadOnlyCollection<LevelImage>(list);
        }

        private void Shuffle(IList<LevelImage> array)
        {
            var random = new Random();

            var index = array.Count;

            while (index > 1)
            {
                var randomIndex = random.Next(index--);
                (array[index], array[randomIndex]) = (array[randomIndex], array[index]);
            }
        }
    }
}