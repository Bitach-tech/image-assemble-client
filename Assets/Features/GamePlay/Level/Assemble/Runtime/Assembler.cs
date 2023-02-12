using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Level.ImageStorage.Runtime;
using GamePlay.Loop.Difficulties;
using Global.MessageBrokers.Runtime;
using Global.UI.UiStateMachines.Runtime;
using Global.Updaters.Runtime.Abstract;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace GamePlay.Level.Assemble.Runtime
{
    [DisallowMultipleComponent]
    public class Assembler : MonoBehaviour, IAssembler, IUiState
    {
        [Inject]
        private void Construct(IUiStateMachine uiStateMachine, IUpdater updater, UiConstraints constraints)
        {
            _updater = updater;
            _constraints = constraints;
            _uiStateMachine = uiStateMachine;
        }

        [SerializeField] private GameObject _body;
        [SerializeField] private Image _preview;
        [SerializeField] private ImageViewDictionary _difficultyImages;

        private IUpdater _updater;
        private CancellationTokenSource _cancellation;
        private IUiStateMachine _uiStateMachine;
        private UiConstraints _constraints;

        public UiConstraints Constraints => _constraints;
        public string Name => "Assembler";

        private void Awake()
        {
            _body.SetActive(false);
        }

        public void Recover()
        {
            _body.SetActive(true);
        }

        public void Exit()
        {
            _body.SetActive(false);
        }

        public void Begin(LevelImage[] images, LevelDifficulty difficulty)
        {
            _uiStateMachine.EnterAsStack(this);
            _body.SetActive(true);

            var view = _difficultyImages[difficulty];

            Process(view, images, difficulty).Forget();
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

                view.Show(correct, others, _updater);
                _preview.sprite = image.Preview;

                await UniTask.WaitUntil(() => view.IsAssembled() == true, PlayerLoopTiming.Update, _cancellation.Token);
                
                view.Lock();

                await view.Hide(_cancellation.Token, _updater);
            }

            Msg.Publish(new AssembledEvent());
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
    }
}