using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Services.Setup.Abstract.Scenes;
using UnityEngine;

namespace Global.Services.Setup.Abstract
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