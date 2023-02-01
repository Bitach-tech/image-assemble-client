using Cysharp.Threading.Tasks;
using Features.Common.DiContainer.Abstract;
using Features.Global.Common;
using Features.Global.Services.Common.Abstract;
using Features.Global.Services.Common.Abstract.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.Global.Services.Loggers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.ServicePrefix + "Logger",
        menuName = GlobalAssetsPaths.Logger + "Service")]
    public class LoggerAsset : GlobalServiceAsset
    {
        [SerializeField] [Indent] private Logger _prefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks)
        {
            var logger = Instantiate(_prefab);
            logger.name = "Logger";

            builder.RegisterComponent(logger)
                .As<ILogger>();

            serviceBinder.AddToModules(logger);
        }
    }
}