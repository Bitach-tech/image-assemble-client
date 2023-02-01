using Cysharp.Threading.Tasks;
using Features.Common.DiContainer.Abstract;
using Features.Common.Local.Services.Abstract;
using Features.GamePlay.Common.Paths;
using Features.GamePlay.Loop.Logs;
using Features.Global.Services.ScenesFlow.Runtime.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.GamePlay.Loop.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GamePlayAssetsPaths.ServicePrefix + "LevelLoop",
        menuName = GamePlayAssetsPaths.LevelLoop + "Service")]
    public class LevelLoopAsset : LocalServiceAsset
    {
        [SerializeField] [Indent] private LevelLoopLogSettings _logSettings;
        [SerializeField] [Indent] private LevelLoop _prefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            ILocalCallbacks callbacks)
        {
            var levelLoop = Instantiate(_prefab);
            levelLoop.name = "LevelLoop";

            builder.Register<LevelLoopLogger>()
                .WithParameter(_logSettings);

            builder.RegisterComponent(levelLoop)
                .AsCallbackListener();

            serviceBinder.AddToModules(levelLoop);
        }
    }
}