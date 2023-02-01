using Global.Common;

namespace Global.Publisher.Advertisement.Common
{
    public static class AdvertisementRoutes
    {
        private const string _paths = GlobalAssetsPaths.Root + "Audio/";
        private const string _servicePrefix = GlobalAssetsPrefixes.Service + "Audio/";

        public const string ServiceName = _servicePrefix + "AudioPlayer";
        public const string ServicePath = _paths + "Service";
    }
}