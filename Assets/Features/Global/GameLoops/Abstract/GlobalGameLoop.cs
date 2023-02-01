using UnityEngine;

namespace Features.Global.GameLoops.Abstract
{
    public abstract class GlobalGameLoop : MonoBehaviour
    {
        public abstract void Begin();

        public abstract void OnAwake();
    }
}