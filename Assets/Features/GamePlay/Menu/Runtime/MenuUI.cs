using System.Collections.Generic;
using Common.Local.Services.Abstract.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Background.Runtime;
using GamePlay.Loop.Difficulties;
using Global.Publisher.Abstract.Advertisment;
using Global.Publisher.Abstract.DataStorages;
using Global.Publisher.Abstract.Saves;
using Global.System.MessageBrokers.Runtime;
using Global.UI.UiStateMachines.Runtime;
using UnityEngine;
using VContainer;

namespace GamePlay.Menu.Runtime
{
    [DisallowMultipleComponent]
    public class MenuUI : MonoBehaviour, IMenuUI, IUiState, ILocalAwakeListener, ILocalSwitchListener
    {
        [Inject]
        private void Construct(
            IUiStateMachine uiStateMachine,
            IGameBackground background,
            IAds ads,
            IDataStorage storage,
            UiConstraints constraints)
        {
            _storage = storage;
            _ads = ads;
            _background = background;
            _uiStateMachine = uiStateMachine;
            _constraints = constraints;
        }

        [SerializeField] private GameObject _body;
        [SerializeField] private int _freeCounter = 5;
        [SerializeField] private List<LevelSelector> _selectors = new();

        private UiConstraints _constraints;
        private IUiStateMachine _uiStateMachine;

        private IGameBackground _background;
        private IAds _ads;
        private IDataStorage _storage;

        public UiConstraints Constraints => _constraints;
        public string Name => "MainMenu";

        public void OnAwake()
        {
            _body.SetActive(false);

            var save = _storage.GetEntry<LevelsSave>(SavesPaths.Levels);

            for (var i = 0; i < _selectors.Count; i++)
                if (i >= _freeCounter && save.IsRewarded(i) == false)
                    _selectors[i].Construct(true, i);
                else
                    _selectors[i].Construct(false, i);
        }

        public void OnEnabled()
        {
            foreach (var selector in _selectors)
                selector.Selected += OnSelected;
        }

        public void OnDisabled()
        {
            foreach (var selector in _selectors)
                selector.Selected -= OnSelected;
        }

        public void Open()
        {
            _uiStateMachine.EnterAsSingle(this);
            _body.SetActive(true);
            _background.Enable();
        }

        public void Recover()
        {
            _background.Enable();
            _body.SetActive(true);
        }

        public void Exit()
        {
            _body.SetActive(false);
        }

        private void OnSelected(LevelDifficulty difficulty, bool isRewardable, int id)
        {
            ProcessSelection(difficulty, isRewardable, id).Forget();
        }

        private async UniTaskVoid ProcessSelection(LevelDifficulty difficulty, bool isRewardable, int id)
        {
            if (isRewardable == true)
                await _ads.ShowRewarded();

            Debug.Log($"On unlocked: {id}");

            var save = _storage.GetEntry<LevelsSave>(SavesPaths.Levels);
            save.OnRewarded(id);

            var clicked = new PlayClickEvent(difficulty);
            Msg.Publish(clicked);
        }
    }
}