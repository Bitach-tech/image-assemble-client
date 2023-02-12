using Cysharp.Threading.Tasks;
using Global.Publisher.Yandex.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Global.Publisher.Yandex.Debugs.Ads
{
    [DisallowMultipleComponent]
    public class AdsDebug : MonoBehaviour, IAdsDebug
    {
        private const float _rewardTime = 5f;

        [SerializeField] private GameObject _body;
        
        [SerializeField] private GameObject _interstitial;
        [SerializeField] private GameObject _rewarded;

        [SerializeField] private Button _interstitialCloseButton;
        [SerializeField] private Button _rewardedCloseButton;

        [SerializeField] private TMP_Text _timer;
        
        private YandexCallbacks _callbacks;

        private void OnEnable()
        {
            _interstitialCloseButton.onClick.AddListener(OnInterstitialCloseClicked);
            _rewardedCloseButton.onClick.AddListener(OnRewardedCloseClicked);
        }
        
        private void OnDisable()
        {
            _interstitialCloseButton.onClick.RemoveListener(OnInterstitialCloseClicked);
            _rewardedCloseButton.onClick.RemoveListener(OnRewardedCloseClicked);
        }

        public void Construct(YandexCallbacks callbacks)
        {
            _callbacks = callbacks;
        }
        
        public void ShowInterstitial()
        {
            Close();

            _body.SetActive(true);

            _interstitial.SetActive(true);
        }

        public void ShowRewarded()
        {
            Close();
            
            _body.SetActive(true);

            _rewarded.SetActive(true);
            _rewardedCloseButton.gameObject.SetActive(false);

            UniTask.Create(async () =>
            {
                var time = 0f;

                while (time < _rewardTime)
                {
                    time += Time.deltaTime;

                    var delta = _rewardTime - time;

                    _timer.text = $"{(int)delta}";
                    
                    await UniTask.Yield();
                }

                _rewardedCloseButton.gameObject.SetActive(true);
            });
        }

        private void Close()
        {
            _interstitial.SetActive(false);
            _rewarded.SetActive(false);
            
            _body.SetActive(false);
        }

        private void OnInterstitialCloseClicked()
        {
            _callbacks.OnInterstitialShown();
            
            Close();
        }

        private void OnRewardedCloseClicked()
        {
            _callbacks.OnRewardedClose();
            
            Close();
        }
    }
}