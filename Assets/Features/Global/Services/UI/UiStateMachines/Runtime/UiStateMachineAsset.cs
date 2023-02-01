using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Common;
using Global.Setup.Service;
using Global.Setup.Service.Scenes;
using Global.UI.UiStateMachines.Common;
using Global.UI.UiStateMachines.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.UiStateMachines.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = UiStateMachineRouter.ServiceName,
        menuName = UiStateMachineRouter.ServicePath)]
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