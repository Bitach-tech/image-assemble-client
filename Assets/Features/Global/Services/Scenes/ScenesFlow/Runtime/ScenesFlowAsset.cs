using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Common;
using Global.Scenes.ScenesFlow.Common;
using Global.Scenes.ScenesFlow.Logs;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
using Global.Setup.Service;
using Global.Setup.Service.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Scenes.ScenesFlow.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ScenesFlowRoutes.ServiceName,
        menuName = ScenesFlowRoutes.ServicePath)]
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