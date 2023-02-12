using System;
using Cysharp.Threading.Tasks;
using Global.ResourcesCleaners.Logs;

namespace Global.ResourcesCleaners.Runtime
{
    public class ResourcesCleaner : IResourcesCleaner
    {
        public ResourcesCleaner(ResourcesCleanerLogger logger)
        {
            _logger = logger;
        }

        private readonly ResourcesCleanerLogger _logger;

        public async UniTask CleanUp()
        {
            GC.Collect();

            //await Resources.UnloadUnusedAssets();

            _logger.OnCleaned();
        }
    }
}