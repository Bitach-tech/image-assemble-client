using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Setup.Service.Scenes;
using UnityEngine;

namespace Global.Setup.Service
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