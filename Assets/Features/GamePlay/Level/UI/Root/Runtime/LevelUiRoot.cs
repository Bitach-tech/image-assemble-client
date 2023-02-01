using GamePlay.Level.UI.Overlay.Runtime;
using Global.Services.External.ServiceSDK.Advertisment.Abstract;
using Global.Services.UI.UiStateMachines.Runtime;
using UnityEngine;
using VContainer;

namespace GamePlay.Level.UI.Root.Runtime
{
    [DisallowMultipleComponent]
    public class LevelUiRoot : MonoBehaviour, IUiState, ILevelUiRoot
    {
        [Inject]
        private void Construct(
            IUiStateMachine uiStateMachine,
            IAds ads,
            ILevelOverlay overlay,
            UiConstraints constraints)
        {
            _overlay = overlay;
            _uiStateMachine = uiStateMachine;
            _constraints = constraints;
        }

        private UiConstraints _constraints;
        private IUiStateMachine _uiStateMachine;

        private readonly WaitForSeconds _wait = new(180f);
        private ILevelOverlay _overlay;

        public UiConstraints Constraints => _constraints;
        public string Name => "Paint";

        public void Open()
        {
            _uiStateMachine.EnterAsSingle(this);
            _overlay.Open();
        }

        public void ShowAssembledScreen()
        {
            _overlay.ShowAssembledScreen();
        }

        public void HideAssembledScreen()
        {
            _overlay.HideAssembledScreen();
        }

        public void Recover()
        {
        }

        public void Exit()
        {
            StopAllCoroutines();
        }
    }
}