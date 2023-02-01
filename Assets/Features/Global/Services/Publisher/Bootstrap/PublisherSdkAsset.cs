using Common.DiContainer.Abstract;
using Global.Publisher.Advertisement.Abstract;
using Global.Publisher.Common;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Publisher.Bootstrap
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PublisherRoutes.ServiceName,
        menuName = PublisherRoutes.ServicePath)]
    public class PublisherSdkAsset : ScriptableObject, IGlobalServiceFactory
    {
        public void Create(IDependencyRegister builder, IGlobalServiceBinder serviceBinder, IGlobalCallbacks callbacks)
        {
            builder.Register<Ads>()
                .As<IAds>();
        }
    }
}