using Cysharp.Threading.Tasks;
using Features.Common.DiContainer.Abstract;
using Features.Global.Common;
using Features.Global.Services.Common.Abstract;
using Features.Global.Services.Common.Abstract.Scenes;
using Features.Global.Services.ResourcesCleaners.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.Global.Services.ResourcesCleaners.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.ServicePrefix + "ResourcesCleaner",
        menuName = GlobalAssetsPaths.ResourceCleaner + "Service")]
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