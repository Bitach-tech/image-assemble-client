using System;
using System.Collections.Generic;
using Global.Updaters.Runtime.Abstract;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace GamePlay.Level.Assemble.Runtime
{
    [DisallowMultipleComponent]
    public class PartView : MonoBehaviour, IUpdatable
    {
        private const float _speed = 2500f;
        private const float _epsilon = 1f;

        [SerializeField] private Button _leftButton;
        [SerializeField] private Button _rightButton;

        [SerializeField] private RectTransform _root;

        [SerializeField] private Image[] _views;

        private bool _isCorrect;
        private float _width;
        private int _current;
        private int _viewsCount;
        private float _correctX;

        private Vector2 _targetPosition;

        public bool IsCorrect => _isCorrect;

        private void Awake()
        {
            _width = _views[0].rectTransform.rect.width;
        }

        private void OnEnable()
        {
            _leftButton.onClick.AddListener(OnLeftClicked);
            _rightButton.onClick.AddListener(OnRightClicked);
        }

        private void OnDisable()
        {
            _leftButton.onClick.RemoveListener(OnLeftClicked);
            _rightButton.onClick.RemoveListener(OnRightClicked);
        }

        public void Construct(Sprite correct, Sprite[] others)
        {
            _isCorrect = false;

            var all = new List<Sprite>(others) { correct };
            _viewsCount = all.Count;

            CreateOnDemand(_views.Length);

            foreach (var view in _views)
                view.gameObject.SetActive(false);

            Shuffle(all);

            for (var i = 0; i < all.Count; i++)
            {
                if (all[i] != correct)
                    continue;

                _correctX = -_width * i;
            }

            for (var i = 0; i < all.Count; i++)
            {
                var view = _views[i];

                view.gameObject.SetActive(true);
                view.sprite = all[i];
            }

            var random = Random.Range(0, all.Count);

            _current = random;
            MoveTo(_current);
        }

        public void Lock()
        {
            _leftButton.gameObject.SetActive(false);
            _rightButton.gameObject.SetActive(false);
        }

        public void Unlock()
        {
            _leftButton.gameObject.SetActive(true);
            _rightButton.gameObject.SetActive(true);
        }

        private void OnLeftClicked()
        {
            if (_current == 0)
                return;

            _current--;

            MoveTo(_current);
        }

        private void OnRightClicked()
        {
            if (_current == _viewsCount - 1)
                return;

            _current++;

            MoveTo(_current);
        }

        private void MoveTo(int index)
        {
            var position = -_width * index;
            _targetPosition = new Vector2(position, 0f);

            SwitchButtons();
        }

        public void OnUpdate(float delta)
        {
            var position = Vector2.MoveTowards(_root.anchoredPosition, _targetPosition, _speed * delta);
            
            _root.anchoredPosition = position;

            var distance = Mathf.Abs(position.x - _correctX);

            if (distance < _epsilon)
                _isCorrect = true;
            else
                _isCorrect = false;
        }

        private void SwitchButtons()
        {
            _leftButton.gameObject.SetActive(true);
            _rightButton.gameObject.SetActive(true);

            if (_current == 0)
                _leftButton.gameObject.SetActive(false);

            if (_current == _viewsCount - 1)
                _rightButton.gameObject.SetActive(false);
        }

        private void CreateOnDemand(int total)
        {
            var delta = _views.Length - total;

            if (delta <= 0)
                return;

            var startLength = _views.Length;

            Array.Resize(ref _views, _views.Length + delta);

            for (var i = 0; i < delta; i++)
            {
                var view = Instantiate(_views[0], _root);
                _views[startLength + i] = view;
            }
        }

        private void Shuffle(IList<Sprite> array)
        {
            var random = new System.Random();

            var index = array.Count;

            while (index > 1)
            {
                var randomIndex = random.Next(index--);
                (array[index], array[randomIndex]) = (array[randomIndex], array[index]);
            }
        }
    }
}