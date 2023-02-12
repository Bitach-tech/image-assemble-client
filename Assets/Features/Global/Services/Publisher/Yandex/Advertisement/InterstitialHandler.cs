using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.Advertisment;
using Global.Publisher.Yandex.Common;
using UnityEngine;

namespace Global.Publisher.Yandex.Advertisement
{
    public class InterstitialHandler
    {
        public InterstitialHandler(
            YandexCallbacks callbacks,
            AdsInternal ads)
        {
            _callbacks = callbacks;
            _ads = ads;
        }

        private readonly YandexCallbacks _callbacks;
        private readonly AdsInternal _ads;

        private UniTaskCompletionSource<InterstitialResult> _completion;

        public async UniTask Show()
        {
            _callbacks.InterstitialShown += OnShown;
            _callbacks.InterstitialFailed += OnFailed;

            _completion = new UniTaskCompletionSource<InterstitialResult>();

            AudioListener.pause = true;

            _ads.ShowInterstitial();
            
            await _completion.Task;
            
            AudioListener.pause = false;

            _callbacks.InterstitialShown -= OnShown;
            _callbacks.InterstitialFailed -= OnFailed;
        }

        private void OnShown()
        {
            _completion.TrySetResult(InterstitialResult.Success);
        }

        private void OnFailed(string message)
        {
            Debug.LogError($"Interstitial failed: {message}");
            _completion.TrySetResult(InterstitialResult.Fail);
        }
    }
}