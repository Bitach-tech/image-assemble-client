using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Global.System.Updaters.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Level.Assemble.Runtime
{
    [DisallowMultipleComponent]
    public class ImageView : MonoBehaviour
    {
        [SerializeField] private PartView[] _allViews;

        private PartView[] _selectedViews;

        private readonly List<PartView> _active = new();

        private void Awake()
        {
            transform.localScale = Vector3.zero;
        }

        public void Show(Sprite[] correctImage, Sprite[][] otherImages, IUpdater updater)
        {
            var slicesLength = correctImage.Length;

            _selectedViews = new PartView[slicesLength];

            foreach (var view in _allViews)
                view.gameObject.SetActive(false);

            for (var i = 0; i < slicesLength; i++)
            {
                _selectedViews[i] = _allViews[i];
                _selectedViews[i].gameObject.SetActive(true);
            }

            foreach (var view in _selectedViews)
                updater.Add(view);

            transform.DOScale(Vector3.one, 1f);

            _active.Clear();

            for (var i = 0; i < slicesLength; i++)
            {
                var correct = correctImage[i];

                var otherList = new List<Sprite>();

                foreach (var other in otherImages)
                    otherList.Add(other[i]);

                _selectedViews[i].Unlock();
                _selectedViews[i].Construct(correct, otherList.ToArray());

                _active.Add(_selectedViews[i]);
            }
        }

        public void Lock()
        {
            foreach (var view in _selectedViews)
                view.Lock();
        }

        public void Assemble()
        {
            Debug.Log("Assemble");
            foreach (var view in _selectedViews)
                view.MoveToCorrect();
        }

        public bool IsAssembled()
        {
            foreach (var active in _active)
                if (active.IsCorrect == false)
                    return false;

            return true;
        }

        public async UniTask Hide(CancellationToken cancellation, IUpdater updater)
        {
            foreach (var view in _selectedViews)
                updater.Remove(view);

            var completion = new UniTaskCompletionSource();

            const int delay = 1500;

            await UniTask.Delay(delay, DelayType.DeltaTime, PlayerLoopTiming.Update, cancellation);

            void OnHidden()
            {
                completion.TrySetResult();
            }

            var sequence = DOTween.Sequence();

            sequence.Append(transform.DOScale(Vector3.zero, 1f));
            sequence.AppendCallback(OnHidden);
            sequence.Play();

            await using (cancellation.Register(() => { completion.TrySetCanceled(); }))
            {
                await completion.Task;
            }
        }
    }
}