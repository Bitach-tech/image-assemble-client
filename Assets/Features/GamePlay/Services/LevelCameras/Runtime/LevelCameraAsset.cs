using Cysharp.Threading.Tasks;
using Features.Common.DiContainer.Abstract;
using Features.Common.Local.Services.Abstract;
using Features.GamePlay.Common.Paths;
using Features.GamePlay.Services.LevelCameras.Logs;
using Features.Global.Services.ScenesFlow.Runtime.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.GamePlay.Services.LevelCameras.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GamePlayAssetsPaths.ServicePrefix + "LevelCamera",
        menuName = GamePlayAssetsPaths.LevelCamera + "Service")]
    public class LevelCameraAsset : LocalServiceAsset
    {
        [SerializeField] [Indent] private LevelCameraConfigAsset _config;
        [SerializeField] [Indent] private LevelCameraLogSettings _logSettings;
        [SerializeField] [Indent] private LevelCamera _prefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            ILocalCallbacks callbacks)
        {
            var levelCamera = Instantiate(_prefab);
            levelCamera.name = "LevelCamera";

            builder.Register<LevelCameraLogger>()
                .WithParameter(_logSettings)
                .AsSelf();

            builder.Register<LevelCameraConfig>()
                .WithParameter(_config)
                .As<ILevelCameraConfig>();

            builder.RegisterComponent(levelCamera)
                .As<ILevelCamera>()
                .AsCallbackListener();

            serviceBinder.AddToModules(levelCamera);
        }
    }
}