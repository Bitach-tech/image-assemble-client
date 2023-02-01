using Common.DiContainer.Abstract;
using Common.Local.Services.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Common.Paths;
using Global.Services.Scenes.ScenesFlow.Runtime.Abstract;
using Global.Services.UI.UiStateMachines.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.UI.Root.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GamePlayAssetsPaths.ServicePrefix + "PaintLoop",
        menuName = GamePlayAssetsPaths.PuzzleLoop + "Service")]
    public class LevelUiRootAsset : LocalServiceAsset
    {
        [SerializeField] private UiConstraints _constraints;
        [SerializeField] private LevelUiRoot _prefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            ILocalCallbacks callbacks)
        {
            var loop = Instantiate(_prefab);
            loop.name = "PaintLoop";

            builder.RegisterComponent(loop)
                .WithParameter(_constraints)
                .As<ILevelUiRoot>();

            serviceBinder.AddToModules(loop);
        }
    }
}