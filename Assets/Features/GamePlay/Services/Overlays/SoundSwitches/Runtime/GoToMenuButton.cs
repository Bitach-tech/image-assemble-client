using Features.GamePlay.Loop.Events;
using Features.Global.Services.MessageBrokers.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace Features.GamePlay.Services.Overlays.SoundSwitches.Runtime
{
    [DisallowMultipleComponent]
    public class GoToMenuButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            Msg.Publish(new MenuRequestEvent());
        }
    }
}