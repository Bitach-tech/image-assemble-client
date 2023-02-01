using Cysharp.Threading.Tasks;

namespace Global.Services.External.ServiceSDK.Advertisment.Abstract
{
    public interface IAds
    {
        void ShowInterstitial();
        UniTask<RewardAdResult> ShowRewarded();
    }
}