using Cysharp.Threading.Tasks;
using Features.Common.DiContainer.Abstract;
using Features.Global.Common;
using Features.Global.Services.Common.Abstract;
using Features.Global.Services.Common.Abstract.Scenes;
using Features.Global.Services.UiStateMachines.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.Global.Services.UiStateMachines.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.ServicePrefix + "UiStateMachine",
        menuName = GlobalAssetsPaths.UiStateMachine + "Service")]
    public class UiStateMachineAsset : GlobalServiceAsset
    {
        [SerializeField] [Indent] private UiStateMachineLogSettings _logSettings;
        [SerializeField] [Indent] private UiStateMachine _prefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks)
        {
            var stateMachine = Instantiate(_prefab);
            stateMachine.name = "UiStateMachine";

            builder.Register<UiStateMachineLogger>()
                .WithParameter(_logSettings);

            builder.RegisterComponent(stateMachine)
                .As<IUiStateMachine>();

            serviceBinder.AddToModules(stateMachine);
        }
    }
}