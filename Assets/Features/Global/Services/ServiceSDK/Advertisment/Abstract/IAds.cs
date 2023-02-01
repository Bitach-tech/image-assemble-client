using Cysharp.Threading.Tasks;

namespace Features.Global.Services.ServiceSDK.Advertisment.Abstract
{
    public interface IAds
    {
        void ShowInterstitial();
        UniTask<RewardAdResult> ShowRewarded();
    }
}