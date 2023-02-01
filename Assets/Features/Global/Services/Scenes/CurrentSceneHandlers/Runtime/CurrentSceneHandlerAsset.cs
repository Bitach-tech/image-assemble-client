using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Common;
using Global.Scenes.CurrentSceneHandlers.Common;
using Global.Scenes.CurrentSceneHandlers.Logs;
using Global.Setup.Service;
using Global.Setup.Service.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Scenes.CurrentSceneHandlers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CurrentSceneHandlerRoutes.ServiceName,
        menuName = CurrentSceneHandlerRoutes.ServicePath)]
    public class CurrentSceneHandlerAsset : GlobalServiceAsset
    {
        [SerializeField] [Indent] private CurrentSceneHandlerLogSettings _logSettings;
        [SerializeField] [Indent] private CurrentSceneHandler _prefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks)
        {
            var sceneHandler = Instantiate(_prefab);
            sceneHandler.name = "CurrentSceneHandler";

            builder.Register<CurrentSceneHandlerLogger>()
                .WithParameter(_logSettings);

            builder.RegisterComponent(sceneHandler)
                .As<ICurrentSceneHandler>();

            serviceBinder.AddToModules(sceneHandler);
        }
    }
}