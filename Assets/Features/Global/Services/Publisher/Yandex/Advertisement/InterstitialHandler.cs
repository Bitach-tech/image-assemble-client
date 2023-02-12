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
            var completion = new UniTaskCompletionSource<InterstitialResult>();
            
            void OnShown()
            {
                completion.TrySetResult(InterstitialResult.Success);
            }

            void OnFailed(string message)
            {
                Debug.LogError($"Interstitial failed: {message}");
                completion.TrySetResult(InterstitialResult.Fail);
            }
            
            _callbacks.InterstitialShown += OnShown;
            _callbacks.InterstitialFailed += OnFailed;

            _ads.ShowInterstitial_Internal();
            
            await completion.Task;

            _callbacks.InterstitialShown -= OnShown;
            _callbacks.InterstitialFailed -= OnFailed;
        }
    }
}