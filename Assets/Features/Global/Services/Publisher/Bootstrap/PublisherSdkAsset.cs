using Common.DiContainer.Abstract;
using Global.Publisher.Common;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Publisher.Bootstrap
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PublisherRoutes.ServiceName,
        menuName = PublisherRoutes.ServicePath)]
    public abstract class PublisherSdkAsset : ScriptableObject, IGlobalServiceFactory
    {
        public abstract void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks);
    }
}