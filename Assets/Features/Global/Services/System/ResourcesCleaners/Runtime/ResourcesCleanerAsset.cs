using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Common;
using Global.Setup.Service;
using Global.Setup.Service.Scenes;
using Global.System.ResourcesCleaners.Common;
using Global.System.ResourcesCleaners.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.ResourcesCleaners.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ResourcesCleanerRouter.ServiceName,
        menuName = ResourcesCleanerRouter.ServicePath)]
    public class ResourcesCleanerAsset : GlobalServiceAsset
    {
        [SerializeField] [Indent] private ResourcesCleanerLogSettings _logSettings;
        [SerializeField] [Indent] private ResourcesCleaner _prefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks)
        {
            var resourcesCleaner = Instantiate(_prefab);
            resourcesCleaner.name = "ResourcesCleaner";

            builder.Register<ResourcesCleanerLogger>().WithParameter(_logSettings);

            builder.RegisterComponent(resourcesCleaner)
                .As<IResourcesCleaner>();

            serviceBinder.AddToModules(resourcesCleaner);
        }
    }
}