using Cysharp.Threading.Tasks;
using Features.Common.DiContainer.Abstract;
using Features.Global.Common;
using Features.Global.Services.Common.Abstract;
using Features.Global.Services.Common.Abstract.Scenes;
using Features.Global.Services.ServiceSDK.Advertisment.Abstract;
using Features.Global.Services.ServiceSDK.Authentications.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.Global.Services.ServiceSDK.Bootstrap
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