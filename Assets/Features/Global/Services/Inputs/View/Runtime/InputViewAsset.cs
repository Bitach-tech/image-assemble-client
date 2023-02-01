using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Common;
using Global.Inputs.Common;
using Global.Inputs.Constranits.Storage;
using Global.Inputs.View.Logs;
using Global.Setup.Service;
using Global.Setup.Service.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Inputs.View.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = InputRouter.ServiceName,
        menuName = InputRouter.ServicePath)]
    public class InputViewAsset : GlobalServiceAsset
    {
        [SerializeField] [Indent] private InputViewLogSettings _logSettings;
        [SerializeField] [Indent] private InputView _prefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks)
        {
            var inputView = Instantiate(_prefab);
            inputView.name = "InputView";

            builder.Register<InputViewLogger>()
                .WithParameter(_logSettings);

            builder.RegisterComponent(inputView)
                .AsImplementedInterfaces()
                .AsCallbackListener();

            builder.Register<InputConstraintsStorage>()
                .As<IInputConstraintsStorage>();

            serviceBinder.AddToModules(inputView);
        }
    }
}