using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Common;
using Global.Services.Cameras.CurrentCameras.Logs;
using Global.Services.Setup.Abstract;
using Global.Services.Setup.Abstract.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.Cameras.CurrentCameras.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.ServicePrefix + "CurrentCamera",
        menuName = GlobalAssetsPaths.CurrentCamera + "Service", order = 1)]
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