using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Cameras.CurrentCameras.Common;
using Global.Cameras.CurrentCameras.Logs;
using Global.Setup.Service;
using Global.Setup.Service.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Cameras.CurrentCameras.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CurrentCameraRoutes.ServiceName,
        menuName = CurrentCameraRoutes.ServicePath)]
    public class CurrentCameraAsset : GlobalServiceAsset
    {
        [SerializeField] [Indent] private CurrentCameraLogSettings _logSettings;
        [SerializeField] [Indent] private CurrentCamera _prefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks)
        {
            var currentCamera = Instantiate(_prefab);
            currentCamera.name = "CurrentCamera";

            builder.Register<CurrentCameraLogger>()
                .WithParameter(_logSettings);

            builder.RegisterComponent(currentCamera)
                .As<ICurrentCamera>()
                .AsCallbackListener();

            serviceBinder.AddToModules(currentCamera);
        }
    }
}