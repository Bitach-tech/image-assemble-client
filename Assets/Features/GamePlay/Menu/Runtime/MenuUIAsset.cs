using Cysharp.Threading.Tasks;
using Features.Common.DiContainer.Abstract;
using Features.Common.Local.Services.Abstract;
using Features.GamePlay.Common.Paths;
using Features.Global.Services.ScenesFlow.Handling.Data;
using Features.Global.Services.ScenesFlow.Runtime.Abstract;
using Features.Global.Services.UiStateMachines.Runtime;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.GamePlay.Menu.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MenuAssetsPaths.ServicePrefix + "UI", menuName = MenuAssetsPaths.UI)]
    public class MenuUIAsset : LocalServiceAsset
    {
        [SerializeField] private UiConstraints _constraints;
        [SerializeField] [Scene] private string _scene;

        public override async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            ILocalCallbacks callbacks)
        {
            var request = new TypedSceneLoadData<MenuUI>(_scene);

            var result = await sceneLoader.Load(request);
            var ui = result.Searched;

            builder.RegisterComponent(ui)
                .WithParameter(_constraints)
                .As<IMenuUI>()
                .AsCallbackListener();
        }
    }
}