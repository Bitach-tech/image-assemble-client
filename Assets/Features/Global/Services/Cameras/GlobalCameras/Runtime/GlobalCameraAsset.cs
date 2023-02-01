using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Common;
using Global.Services.Cameras.GlobalCameras.Logs;
using Global.Services.Setup.Abstract;
using Global.Services.Setup.Abstract.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.Cameras.GlobalCameras.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.ServicePrefix + "GlobalCamera",
        menuName = GlobalAssetsPaths.GlobalCamera + "Service")]
    public class GlobalCameraAsset : GlobalServiceAsset
    {
        [SerializeField] [Indent] private GlobalCameraLogSettings _logSettings;
        [SerializeField] [Indent] private GlobalCamera _prefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks)
        {
            var globalCamera = Instantiate(_prefab);
            globalCamera.name = "Camera_Global";
            globalCamera.gameObject.SetActive(false);

            builder.Register<GlobalCameraLogger>()
                .WithParameter(_logSettings);

            builder.RegisterComponent(globalCamera)
                .As<IGlobalCamera>()
                .AsCallbackListener();

            serviceBinder.AddToModules(globalCamera);
        }
    }
}