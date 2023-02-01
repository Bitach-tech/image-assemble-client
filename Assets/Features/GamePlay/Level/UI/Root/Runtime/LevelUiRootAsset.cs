using Cysharp.Threading.Tasks;
using Features.Common.DiContainer.Abstract;
using Features.Common.Local.Services.Abstract;
using Features.GamePlay.Common.Paths;
using Features.Global.Services.ScenesFlow.Runtime.Abstract;
using Features.Global.Services.UiStateMachines.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.GamePlay.Level.UI.Root.Runtime
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