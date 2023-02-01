using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Publisher.Advertisement.Abstract;
using Global.Publisher.Authentications.Runtime;
using Global.Publisher.Common;
using Global.Setup.Service;
using Global.Setup.Service.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Publisher.Bootstrap
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PublisherRoutes.ServiceName,
        menuName = PublisherRoutes.ServicePath)]
    public class PublisherSdkAsset : GlobalServiceAsset
    {
        [SerializeField] private Ads _prefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks)
        {
            var ads = Instantiate(_prefab);
            ads.name = "ServiceSDK";

            var auth = ads.GetComponent<Authentication>();

            builder.RegisterComponent(ads)
                .As<IAds>();

            builder.RegisterComponent(auth)
                .As<IAuthentication>();

            serviceBinder.AddToModules(ads);
        }
    }
}