using System;
using Cysharp.Threading.Tasks;
using Global.Services.System.ResourcesCleaners.Logs;
using UnityEngine;
using VContainer;

namespace Global.Services.System.ResourcesCleaners.Runtime
{
    public class ResourcesCleaner : MonoBehaviour, IResourcesCleaner
    {
        [Inject]
        private void Construct(ResourcesCleanerLogger logger)
        {
            _logger = logger;
        }

        private ResourcesCleanerLogger _logger;

        public async UniTask CleanUp()
        {
            GC.Collect();

            //await Resources.UnloadUnusedAssets();

            _logger.OnCleaned();
        }
    }
}