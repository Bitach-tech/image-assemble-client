﻿using Cysharp.Threading.Tasks;
using Features.Common.DiContainer.Abstract;
using Features.Global.Common;
using Features.Global.Services.Common.Abstract;
using Features.Global.Services.Common.Abstract.Scenes;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.Global.Services.Overlays.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.ServicePrefix + "Overlay",
        menuName = GlobalAssetsPaths.Overlay + "Service")]
    public class OverlayAsset : GlobalServiceAsset
    {
        [SerializeField] [Scene] private string _scene;

        public override async UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks)
        {
            Debug.Log("Overlay 0");
            var data = new InternalScene<OverlayBootstrapper>(_scene);
            var result = await sceneLoader.Load(data);
            Debug.Log("Overlay 1");

            var bootstrapper = result.Searched;

            foreach (var listener in bootstrapper.EventListeners)
                callbacks.Listen(listener);
        }
    }
}