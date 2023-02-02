using GamePlay.Common.Paths;

namespace GamePlay.Level.ImageStorage.Common
{
    public class ImageStorageRoutes
    {
        private const string _paths = GamePlayAssetsPaths.Root + "ImageStorage/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GamePlayAssetsPrefixes.Service + "ImageStorage";
        
        public const string ProcessorPath = _paths + "Processor";
        public const string ProcessorName = GamePlayAssetsPrefixes.Config + "ImageProcessor";
        
        public const string ImagePath = _paths + "Image";
        public const string ImageName = GamePlayAssetsPrefixes.Config + "Image";
    }
}