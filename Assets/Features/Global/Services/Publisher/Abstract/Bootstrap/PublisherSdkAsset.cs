using Common.DiContainer.Abstract;
using Global.Setup.Service;
using UnityEngine;

namespace Global.Publisher.Abstract.Bootstrap
{
    public abstract class PublisherSdkAsset : ScriptableObject, IGlobalServiceFactory
    {
        public abstract void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks);
    }
}