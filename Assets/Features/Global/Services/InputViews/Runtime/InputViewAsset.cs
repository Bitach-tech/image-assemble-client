using Cysharp.Threading.Tasks;
using Features.Common.DiContainer.Abstract;
using Features.Global.Common;
using Features.Global.Services.Common.Abstract;
using Features.Global.Services.Common.Abstract.Scenes;
using Features.Global.Services.InputViews.ConstraintsStorage;
using Features.Global.Services.InputViews.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.Global.Services.InputViews.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.ServicePrefix + "InputView",
        menuName = GlobalAssetsPaths.InputView + "Service")]
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