using Cysharp.Threading.Tasks;
using Global.Pauses.Runtime;
using Global.Publisher.Abstract.Advertisment;
using Global.Publisher.Yandex.Common;

namespace Global.Publisher.Yandex.Advertisement
{
    public class Ads : IAds
    {
        private Ads(YandexCallbacks callbacks, IPause pause)
        {
            _callbacks = callbacks;
            _pause = pause;
            _internal = new AdsInternal();
        }

        private readonly AdsInternal _internal;
        private readonly YandexCallbacks _callbacks;

        private readonly IPause _pause;

        public void ShowInterstitial()
        {
            ProcessInterstitial().Forget();
        }

        public async UniTask<RewardAdResult> ShowRewarded()
        {
            _pause.Pause();

            var handler = new RewardedHandler(_callbacks, _internal);
            var result = await handler.Show();

            _pause.Continue();

            return result;
        }

        private async UniTaskVoid ProcessInterstitial()
        {
            _pause.Pause();

            var handler = new InterstitialHandler(_callbacks, _internal);
            await handler.Show();

            _pause.Continue();
        }
    }
}