using Common.Local.Services.Abstract.Callbacks;
using Cysharp.Threading.Tasks;
using Plugins.YandexGames.Runtime;
using UnityEngine;

namespace Global.Publisher.Advertisement.Abstract
{
    [DisallowMultipleComponent]
    public class Ads : IAds, ILocalSwitchListener
    {
        private UniTaskCompletionSource<RewardAdResult> _rewardedCompletion;

        public void OnEnabled()
        {
            YandexSDK.instance.onRewardedAdReward += OnRewardShowed;
            YandexSDK.instance.onRewardedAdClosed += OnRewardClosed;
            YandexSDK.instance.onRewardedAdError += OnRewardError;
        }

        public void OnDisabled()
        {
            YandexSDK.instance.onRewardedAdReward -= OnRewardShowed;
            YandexSDK.instance.onRewardedAdClosed -= OnRewardClosed;
            YandexSDK.instance.onRewardedAdError -= OnRewardError;
        }

        public void ShowInterstitial()
        {
            YandexSDK.instance.ShowInterstitial();
        }

        public async UniTask<RewardAdResult> ShowRewarded()
        {
            _rewardedCompletion = new UniTaskCompletionSource<RewardAdResult>();

            YandexSDK.instance.ShowRewarded("1");

            var result = await _rewardedCompletion.Task;
            AudioListener.pause = false;

            return result;
        }

        private void OnRewardShowed(string data)
        {
            _rewardedCompletion.TrySetResult(RewardAdResult.Applied);
        }

        private void OnRewardClosed(int data)
        {
            _rewardedCompletion.TrySetResult(RewardAdResult.Canceled);
        }

        private void OnRewardError(string data)
        {
            _rewardedCompletion.TrySetResult(RewardAdResult.Error);
        }
    }
}