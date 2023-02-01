using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Common;
using Global.Services.External.ServiceSDK.Advertisment.Abstract;
using Global.Services.External.ServiceSDK.Authentications.Runtime;
using Global.Services.Setup.Abstract;
using Global.Services.Setup.Abstract.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.External.ServiceSDK.Bootstrap
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.ServicePrefix + "ServiceSDK",
        menuName = GlobalAssetsPaths.ServiceSDK + "Service")]
    public class ServiceSdkAsset : GlobalServiceAsset
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