using Cysharp.Threading.Tasks;
using Features.Common.DiContainer.Abstract;
using Features.Global.Common;
using Features.Global.Services.Common.Abstract;
using Features.Global.Services.Common.Abstract.Scenes;
using Features.Global.Services.CurrentSceneHandlers.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.Global.Services.CurrentSceneHandlers.Runtime
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