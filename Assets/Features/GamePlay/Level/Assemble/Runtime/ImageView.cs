using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Level.Assemble.Runtime
{
    [DisallowMultipleComponent]
    public class ImageView : MonoBehaviour
    {
        [SerializeField] private PartView[] _views;

        private readonly List<PartView> _active = new();

        public void Show(Sprite[] correctImage, Sprite[][] otherImages)
        {
            var length = correctImage.Length;
            
            CreateOnDemand(length);
            
            _active.Clear();

            for (var i = 0; i < length; i++)
            {
                var correct = correctImage[i];

                var otherList = new List<Sprite>();

                foreach (var other in otherImages)
                    otherList.Add(other[i]);

                _views[i].Unlock();
                _views[i].Construct(correct, otherList.ToArray());

                _active.Add(_views[i]);
            }
        }

        public void Lock()
        {
            foreach (var view in _views)
                view.Lock();
        }

        public bool IsAssembled()
        {
            foreach (var active in _active)
            {
                if (active.IsCorrect == false)
                    return false;
            }

            return true;
        }
        
        private void CreateOnDemand(int total)
        {
            var delta = total - _views.Length;

            if (delta <= 0)
                return;

            var startLength = _views.Length;

            Array.Resize(ref _views, _views.Length + delta);

            for (var i = 0; i < delta; i++)
            {
                var view = Instantiate(_views[0], _views[0].transform.parent);
                _views[startLength + i] = view;
            }
        }
    }
}
