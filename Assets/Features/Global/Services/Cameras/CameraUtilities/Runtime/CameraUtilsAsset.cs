using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Common;
using Global.Services.Cameras.CameraUtilities.Logs;
using Global.Services.Setup.Abstract;
using Global.Services.Setup.Abstract.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.Cameras.CameraUtilities.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.ServicePrefix + "CameraUtils",
        menuName = GlobalAssetsPaths.CameraUtils + "Service", order = 1)]
    public class CameraUtilsAsset : GlobalServiceAsset
    {
        [SerializeField] [Indent] private CameraUtilsLogSettings _logSettings;
        [SerializeField] [Indent] private CameraUtils _prefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks)
        {
            var utils = Instantiate(_prefab);
            utils.name = "CameraUtils";

            builder.Register<CameraUtilsLogger>()
                .WithParameter(_logSettings);

            builder.RegisterComponent(utils)
                .As<ICameraUtils>()
                .AsCallbackListener();

            serviceBinder.AddToModules(utils);
        }
    }
}