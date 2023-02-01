using Cysharp.Threading.Tasks;
using Features.Common.DiContainer.Abstract;
using Features.Global.Services.ScenesFlow.Runtime.Abstract;
using UnityEngine;

namespace Features.Common.Local.Services.Abstract
{
    public abstract class LocalServiceAsset : ScriptableObject
    {
        public abstract UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            ILocalCallbacks callbacks);
    }
}