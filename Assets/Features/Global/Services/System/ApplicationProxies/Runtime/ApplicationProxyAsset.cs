using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Common;
using Global.Setup.Service;
using Global.Setup.Service.Scenes;
using Global.System.ApplicationProxies.Common;
using Global.System.ApplicationProxies.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.ApplicationProxies.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ApplicationProxyRoutes.ServiceName,
        menuName = ApplicationProxyRoutes.ServicePath)]
    public class ApplicationProxyAsset : GlobalServiceAsset
    {
        [SerializeField] [Indent] private ApplicationProxyLogSettings _logSettings;
        [SerializeField] [Indent] private ApplicationProxy _prefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks)
        {
            var applicationProxy = Instantiate(_prefab);
            applicationProxy.name = "ApplicationProxy";

            builder.Register<ApplicationProxyLogger>()
                .WithParameter(_logSettings);

            builder.RegisterComponent(applicationProxy)
                .As<IApplicationFlow>();
        }
    }
}