using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Common;
using Global.Services.Scenes.ScenesFlow.Logs;
using Global.Services.Scenes.ScenesFlow.Runtime.Abstract;
using Global.Services.Setup.Abstract;
using Global.Services.Setup.Abstract.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.Scenes.ScenesFlow.Runtime
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