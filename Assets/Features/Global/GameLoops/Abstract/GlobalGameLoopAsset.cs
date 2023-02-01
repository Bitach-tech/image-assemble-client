using Features.Common.DiContainer.Abstract;
using Features.Global.Services.Common.Abstract;
using UnityEngine;

namespace Features.Global.GameLoops.Abstract
{
    public abstract class GlobalGameLoopAsset : ScriptableObject
    {
        public abstract GlobalGameLoop Create(IDependencyRegister register, IGlobalServiceBinder binder);
    }
}