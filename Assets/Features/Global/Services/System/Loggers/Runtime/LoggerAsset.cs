using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Setup.Service;
using Global.Setup.Service.Scenes;
using Global.System.Loggers.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.Loggers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LoggerRoutes.ServiceName,
        menuName = LoggerRoutes.ServicePath)]
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