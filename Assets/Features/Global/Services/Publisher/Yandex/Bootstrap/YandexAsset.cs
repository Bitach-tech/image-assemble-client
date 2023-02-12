using Common.DiContainer.Abstract;
using Global.Publisher.Abstract.Advertisment;
using Global.Publisher.Abstract.Bootstrap;
using Global.Publisher.Abstract.DataStorages;
using Global.Publisher.Abstract.Languages;
using Global.Publisher.Abstract.Leaderboards;
using Global.Publisher.Abstract.Purchases;
using Global.Publisher.Abstract.Reviews;
using Global.Publisher.Yandex.Advertisement;
using Global.Publisher.Yandex.Common;
using Global.Publisher.Yandex.DataStorages;
using Global.Publisher.Yandex.Languages;
using Global.Publisher.Yandex.Leaderboard;
using Global.Publisher.Yandex.Purchases;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Publisher.Yandex.Bootstrap
{
    [InlineEditor]
    [CreateAssetMenu(fileName = YandexRoutes.ServiceName, menuName = YandexRoutes.ServicePath)]
    public class YandexAsset : PublisherSdkAsset
    {
        [SerializeField] private YandexCallbacks _callbacksPrefab;
        
        public override void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            var yandexCallbacks = Instantiate(_callbacksPrefab, Vector3.zero, Quaternion.identity);

            builder.RegisterComponent(yandexCallbacks);
            
            builder.Register<Ads>()
                .As<IAds>();

            builder.Register<DataStorage>()
                .As<IDataStorage>()
                .AsCallbackListener();

            builder.Register<LanguageProvider>()
                .As<ILanguageProvider>();

            builder.Register<Leaderboards>()
                .As<ILeaderboards>();

            builder.Register<Reviews.Reviews>()
                .As<IReviews>();

            builder.Register<PurchaseProcessor>()
                .As<IPurchaseProcessor>();
        }
    }
}