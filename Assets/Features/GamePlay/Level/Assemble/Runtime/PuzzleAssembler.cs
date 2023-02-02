using Common.Local.Services.Abstract.Callbacks;
using UnityEngine;

namespace GamePlay.Level.Assemble.Runtime
{
    [DisallowMultipleComponent]
    public class PuzzleAssembler : MonoBehaviour, IPuzzleAssembler, ILocalAwakeListener, ILocalSwitchListener
    {
        public void OnAwake()
        {
        }

        public void OnEnabled()
        {
        }

        public void OnDisabled()
        {
        }
    }
}