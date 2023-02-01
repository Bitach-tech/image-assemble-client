using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Cameras.CameraUtilities.Common;
using Global.Cameras.CameraUtilities.Logs;
using Global.Setup.Service;
using Global.Setup.Service.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Cameras.CameraUtilities.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CameraUtilsRoutes.ServiceName,
        menuName = CameraUtilsRoutes.ServicePath)]
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