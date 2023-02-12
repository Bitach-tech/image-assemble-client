using Common.DiContainer.Abstract;
using Global.ResourcesCleaners.Common;
using Global.ResourcesCleaners.Logs;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.ResourcesCleaners.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ResourcesCleanerRouter.ServiceName,
        menuName = ResourcesCleanerRouter.ServicePath)]
    public class ResourcesCleanerAsset : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private ResourcesCleanerLogSettings _logSettings;

        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<ResourcesCleanerLogger>().WithParameter(_logSettings);

            builder.Register<ResourcesCleaner>()
                .As<IResourcesCleaner>();
        }
    }
}