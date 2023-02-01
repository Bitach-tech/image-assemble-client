using Cysharp.Threading.Tasks;
using Features.Common.DiContainer.Abstract;
using Features.Global.Common;
using Features.Global.Services.Common.Abstract;
using Features.Global.Services.Common.Abstract.Scenes;
using Features.Global.Services.ScenesFlow.Logs;
using Features.Global.Services.ScenesFlow.Runtime.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.Global.Services.ScenesFlow.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.ServicePrefix + "ScenesFlow",
        menuName = GlobalAssetsPaths.ScenesFlow + "Service")]
    public class ScenesFlowAsset : GlobalServiceAsset
    {
        [SerializeField] [Indent] private ScenesFlowLogSettings _logSettings;
        [SerializeField] [Indent] private ScenesLoader _prefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks)
        {
            var loader = Instantiate(_prefab);
            loader.name = "ScenesFlow";

            var unloader = loader.GetComponent<ScenesUnloader>();

            builder.Register<ScenesFlowLogger>()
                .WithParameter(_logSettings);

            builder.RegisterComponent(loader)
                .As<ISceneLoader>();

            builder.RegisterComponent(unloader)
                .As<ISceneUnloader>();

            serviceBinder.AddToModules(loader);
        }
    }
}