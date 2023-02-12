using Common.DiContainer.Abstract;
using Global.ApplicationProxies.Common;
using Global.ApplicationProxies.Logs;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.ApplicationProxies.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ApplicationProxyRoutes.ServiceName,
        menuName = ApplicationProxyRoutes.ServicePath)]
    public class ApplicationProxyAsset : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private ApplicationProxyLogSettings _logSettings;

        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<ApplicationProxyLogger>()
                .WithParameter(_logSettings);

            builder.Register<ApplicationProxy>()
                .As<IApplicationFlow>();
        }
    }
}