using Cysharp.Threading.Tasks;

namespace Global.Publisher.Advertisement.Abstract
{
    public interface IAds
    {
        void ShowInterstitial();
        UniTask<RewardAdResult> ShowRewarded();
    }
}