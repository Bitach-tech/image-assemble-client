using System;
using System.Collections.Generic;
using System.Threading;
using Common.Local.Services.Abstract.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Level.ImageStorage.Runtime;
using GamePlay.Loop.Difficulties;
using Global.Publisher.Abstract.Advertisment;
using Global.System.MessageBrokers.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using Global.UI.UiStateMachines.Runtime;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace GamePlay.Level.Assemble.Runtime
{
    [DisallowMultipleComponent]
    public class Assembler : MonoBehaviour, IAssembler, IUiState, ILocalSwitchListener, IUpdatable
    {
        [Inject]
        private void Construct(
            IUiStateMachine uiStateMachine,
            IUpdater updater,
            IAds ads,
            UiConstraints constraints)
        {
            _ads = ads;
            _updater = updater;
            _constraints = constraints;
            _uiStateMachine = uiStateMachine;
        }

        [SerializeField] private GameObject _body;
        [SerializeField] private Image _preview;
        [SerializeField] private ImageView _view;

        private IAds _ads;
        private IUpdater _updater;
        private IUiStateMachine _uiStateMachine;
        private UiConstraints _constraints;

        private IDisposable _tipRequestListener;
        private ImageView _current;
        private CancellationTokenSource _cancellation;

        public UiConstraints Constraints => _constraints;
        public string Name => "Assembler";

        private void Awake()
        {
            _body.SetActive(false);
        }

        public void OnEnabled()
        {
            _tipRequestListener = Msg.Listen<TipRequestEvent>(OnTipRequested);
        }

        public void OnDisabled()
        {
            _tipRequestListener?.Dispose();
        }

        public void Recover()
        {
            _body.SetActive(true);
        }

        public void Exit()
        {
            _updater.Remove(this);
            _body.SetActive(false);
        }

        public void Begin(LevelImage[] images, LevelDifficulty difficulty)
        {
            _updater.Add(this);
            _uiStateMachine.EnterAsStack(this);
            _body.SetActive(true);

            Process(_view, images, difficulty).Forget();
        }

        public void Stop()
        {
            _cancellation?.Cancel();
            _cancellation = null;
        }

        private async UniTaskVoid Process(ImageView view, LevelImage[] images, LevelDifficulty difficulty)
        {
            Stop();

            _cancellation = new CancellationTokenSource();

            foreach (var image in images)
            {
                var list = new List<LevelImage>(images);
                list.Remove(image);

                var correct = PickSprites(image, difficulty);

                var others = new Sprite[images.Length - 1][];

                for (var i = 0; i < list.Count; i++)
                    others[i] = PickSprites(list[i], difficulty);

                _current = view;
                _current.Show(correct, others);
                _preview.sprite = image.Preview;

                await UniTask.WaitUntil(() => _current.IsAssembled() == true, PlayerLoopTiming.Update,
                    _cancellation.Token);

                _current.Lock();

                await _current.Hide(_cancellation.Token);
            }

            Msg.Publish(new AssembledEvent());
        }

        private void OnTipRequested(TipRequestEvent data)
        {
            ProcessTip().Forget();
        }

        private async UniTaskVoid ProcessTip()
        {
            var result = await _ads.ShowRewarded();
            Debug.Log(result);
            if (result == RewardAdResult.Applied)
                _current.Assemble();
        }

        private Sprite[] PickSprites(LevelImage image, LevelDifficulty difficulty)
        {
            return difficulty switch
            {
                LevelDifficulty.Easy => image.Level0,
                LevelDifficulty.Easy_Black => image.Level0,
                LevelDifficulty.Medium => image.Level1,
                LevelDifficulty.Medium_Black => image.Level1,
                LevelDifficulty.Hard => image.Level2,
                LevelDifficulty.Hard_Black => image.Level2,
                LevelDifficulty.VeryHard => image.Level3,
                LevelDifficulty.VeryHard_Black => image.Level3,
                _ => throw new ArgumentOutOfRangeException(nameof(difficulty), difficulty, null)
            };
        }

        public void OnUpdate(float delta)
        {
            if (_current == null)
                return;
            
            _current.OnUpdate(delta);
        }
    }
}