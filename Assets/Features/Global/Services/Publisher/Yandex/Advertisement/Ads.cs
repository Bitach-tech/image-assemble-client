using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.Advertisment;
using Global.Publisher.Yandex.Common;
using Global.Updaters.Runtime.Abstract;

namespace Global.Publisher.Yandex.Advertisement
{
    public class Ads : IAds
    {
        private Ads(
            YandexCallbacks callbacks,
            IUpdateSpeedSetter speedSetter,
            IUpdateSpeedModifier speedModifier)
        {
            _callbacks = callbacks;
            _speedSetter = speedSetter;
            _speedModifier = speedModifier;
            _internal = new AdsInternal();
        }

        private readonly AdsInternal _internal;
        private readonly YandexCallbacks _callbacks;
        
        private readonly IUpdateSpeedSetter _speedSetter;
        private readonly IUpdateSpeedModifier _speedModifier;

        public void ShowInterstitial()
        {
            ProcessInterstitial().Forget();
        }

        public async UniTask<RewardAdResult> ShowRewarded()
        {
            var speed = _speedModifier.Speed;
            _speedSetter.Set(0f);

            var handler = new RewardedHandler(_callbacks, _internal);
            var result = await handler.Show();

            _speedSetter.Set(speed);

            return result;
        }

        private async UniTaskVoid ProcessInterstitial()
        {
            var speed = _speedModifier.Speed;
            _speedSetter.Set(0f);

            var handler = new InterstitialHandler(_callbacks, _internal);
            await handler.Show();

            _speedSetter.Set(speed);
        }
    }
}