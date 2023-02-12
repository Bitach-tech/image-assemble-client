using System.Runtime.InteropServices;

namespace Global.Publisher.Yandex.Advertisement
{
    public class AdsInternal
    {
        [DllImport("__Internal")]
        private static extern void ShowFullscreenAd();

        [DllImport("__Internal")]
        private static extern int ShowRewardedAd(string placement);

        public void ShowInterstitial()
        {
            ShowFullscreenAd();
        }

        public void ShowRewarded()
        {
            ShowRewardedAd("1");
        }
    }
}