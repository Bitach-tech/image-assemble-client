using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Common;
using Global.Services.Scenes.CurrentSceneHandlers.Logs;
using Global.Services.Setup.Abstract;
using Global.Services.Setup.Abstract.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.Scenes.CurrentSceneHandlers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.ServicePrefix + "CurrentSceneHandler",
        menuName = GlobalAssetsPaths.CurrentSceneHandler + "Service")]
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