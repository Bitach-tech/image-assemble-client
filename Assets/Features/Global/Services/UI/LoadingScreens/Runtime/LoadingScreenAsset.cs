using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Common;
using Global.Services.Setup.Abstract;
using Global.Services.Setup.Abstract.Scenes;
using Global.Services.UI.LoadingScreens.Logs;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.UI.LoadingScreens.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.ServicePrefix + "LoadingScreen",
        menuName = GlobalAssetsPaths.LoadingScreen + "Service")]
    public class LoadingScreenAsset : GlobalServiceAsset
    {
        [SerializeField] [Indent] private LoadingScreenLogSettings _logSettings;
        [SerializeField] [Indent] [Scene] private string _scene;

        public override async UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks)
        {
            var result = await sceneLoader.Load(new InternalScene<LoadingScreen>(_scene));

            var loadingScreen = result.Searched;

            builder.Register<LoadingScreenLogger>()
                .WithParameter(_logSettings);

            builder.RegisterComponent(loadingScreen)
                .As<ILoadingScreen>();

            serviceBinder.AddToModules(loadingScreen);
        }
    }
}