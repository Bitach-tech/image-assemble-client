using Cysharp.Threading.Tasks;
using Features.Common.DiContainer.Abstract;
using Features.Global.Services.Common.Abstract.Scenes;
using UnityEngine;

namespace Features.Global.Services.Common.Abstract
{
    public abstract class GlobalServiceAsset : ScriptableObject
    {
        public abstract UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks);
    }
}