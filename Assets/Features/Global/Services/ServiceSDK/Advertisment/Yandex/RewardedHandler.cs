﻿using Cysharp.Threading.Tasks;
using Features.Global.Services.ServiceSDK.Advertisment.Abstract;
using Plugins.YandexGames.Runtime;
using UnityEngine;

namespace Features.Global.Services.ServiceSDK.Advertisment.Yandex
{
    public class RewardedHandler
    {
        public RewardedHandler(
            YandexCallbacks callbacks,
            AdsInternal ads)
        {
            _callbacks = callbacks;
            _ads = ads;
        }

        private readonly YandexCallbacks _callbacks;
        private readonly AdsInternal _ads;

        private UniTaskCompletionSource<RewardAdResult> _rewardedCompletion;

        public async UniTask<RewardAdResult> Show()
        {
            _callbacks.RewardedAdReward += OnRewardShowed;
            _callbacks.RewardedAdClosed += OnRewardClosed;
            _callbacks.RewardedAdError += OnRewardError;

            _rewardedCompletion = new UniTaskCompletionSource<RewardAdResult>();

            _ads.ShowRewarded();

            var result = await _rewardedCompletion.Task;
            AudioListener.pause = false;

            _callbacks.RewardedAdReward -= OnRewardShowed;
            _callbacks.RewardedAdClosed -= OnRewardClosed;
            _callbacks.RewardedAdError -= OnRewardError;

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