using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Debug.Console.Common;
using Global.Setup.Service;
using Global.Setup.Service.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Debug.Console.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = DebugConsoleRoutes.ServiceName,
        menuName = DebugConsoleRoutes.ServicePath)]
    public class DebugConsoleAsset : GlobalServiceAsset
    {
        [SerializeField] [Indent] private DebugConsole _prefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks)
        {
            var debugConsole = Instantiate(_prefab);
            debugConsole.name = "DebugConsole";

            builder.RegisterComponent(debugConsole)
                .AsCallbackListener();

            serviceBinder.AddToModules(debugConsole);
        }
    }
}