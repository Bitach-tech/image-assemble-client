using System;
using GamePlay.Loop.Difficulties;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Menu.Runtime
{
    [DisallowMultipleComponent]
    public class LevelSelector : MonoBehaviour
    {
        [SerializeField] private LevelDifficulty _difficulty;
        [SerializeField] private GameObject _adSign;
        [SerializeField] private Button _button;

        private bool _isRewardable;
        private int _id;
        
        public event Action<LevelDifficulty, bool, int> Selected;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClicked);
        }

        public void Construct(bool isRewardable, int id)
        {
            _isRewardable = isRewardable;
            _id = id;

            if (_isRewardable == true)
                _adSign.SetActive(true);
            else
                _adSign.SetActive(false);
        }

        private void OnClicked()
        {
            _adSign.SetActive(false);

            Selected?.Invoke(_difficulty, _isRewardable, _id);

            _isRewardable = false;
        }
    }
}