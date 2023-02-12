using Common.DiContainer.Abstract;
using Global.Pauses.Common;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Pauses.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PauseRoutes.ServiceName, menuName = PauseRoutes.ServicePath)]
    public class PauseAsset : ScriptableObject, IGlobalServiceFactory
    {
        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<PauseSwitcher>()
                .As<IPause>();
        }
    }
}