﻿using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
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
using Global.Publisher.Yandex.Debugs;
using Global.Publisher.Yandex.Debugs.Ads;
using Global.Publisher.Yandex.Debugs.Purchases;
using Global.Publisher.Yandex.Debugs.Reviews;
using Global.Publisher.Yandex.Languages;
using Global.Publisher.Yandex.Leaderboard;
using Global.Publisher.Yandex.Purchases;
using Global.Publisher.Yandex.Reviews;
using Global.Setup.Service;
using Global.Setup.Service.Scenes;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Publisher.Yandex.Bootstrap
{
    [InlineEditor]
    [CreateAssetMenu(fileName = YandexRoutes.ServiceName, menuName = YandexRoutes.ServicePath)]
    public class YandexAsset : PublisherSdkAsset
    {
        [SerializeField] [Scene] private string _debugScene;
        [SerializeField] private YandexCallbacks _callbacksPrefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks)
        {
            var yandexCallbacks = Instantiate(_callbacksPrefab, Vector3.zero, Quaternion.identity);

            builder.RegisterComponent(yandexCallbacks);

            RegisterModules(builder);

            if (Application.isEditor == true)
                await RegisterEditorApis(builder, sceneLoader);
            else
                RegisterBuildApis(builder);
        }

        private void RegisterModules(IDependencyRegister builder)
        {
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

        private async UniTask RegisterEditorApis(
            IDependencyRegister builder,
            IGlobalSceneLoader sceneLoader)
        {
            var sceneData = new InternalScene<YandexDebugCanvas>(_debugScene);
            var loadResult = await sceneLoader.LoadAsync(sceneData);

            var canvas = loadResult.Searched;

            builder.Register<AdsDebugAPI>()
                .As<IAdsAPI>()
                .WithParameter<IAdsDebug>(canvas.Ads);

            builder.Register<StorageDebugAPI>()
                .As<IStorageAPI>();

            builder.Register<LanguageDebugAPI>()
                .As<ILanguageAPI>();

            builder.Register<LeaderboardsDebugAPI>()
                .As<ILeaderboardsAPI>();

            builder.Register<PurchasesDebugAPI>()
                .As<IPurchasesAPI>()
                .WithParameter<IPurchaseDebug>(canvas.Purchase);

            builder.Register<ReviewsDebugAPI>()
                .As<IReviewsAPI>()
                .WithParameter<IReviewsDebug>(canvas.Reviews);
        }

        private void RegisterBuildApis(IDependencyRegister builder)
        {
            builder.Register<AdsExternAPI>()
                .As<IAdsAPI>();

            builder.Register<StorageExternAPI>()
                .As<IStorageAPI>();

            builder.Register<LanguageExternAPI>()
                .As<ILanguageAPI>();

            builder.Register<LeaderboardsExternAPI>()
                .As<ILeaderboardsAPI>();

            builder.Register<PurchasesExternAPI>()
                .As<IPurchasesAPI>();

            builder.Register<ReviewsExternAPI>()
                .As<IReviewsAPI>();
        }
    }
}