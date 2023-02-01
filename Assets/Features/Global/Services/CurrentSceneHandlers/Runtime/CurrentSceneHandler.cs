﻿using Cysharp.Threading.Tasks;
using Features.Common.Local.ComposedSceneConfig;
using Features.Global.Services.CurrentSceneHandlers.Logs;
using Features.Global.Services.ResourcesCleaners.Runtime;
using Features.Global.Services.ScenesFlow.Runtime.Abstract;
using UnityEngine;
using VContainer;

namespace Features.Global.Services.CurrentSceneHandlers.Runtime
{
    public class CurrentSceneHandler : MonoBehaviour, ICurrentSceneHandler
    {
        [Inject]
        private void Construct(
            ISceneUnloader unloader,
            IResourcesCleaner resourcesCleaner,
            CurrentSceneHandlerLogger logger)
        {
            _logger = logger;
            _unloader = unloader;
            _resourcesCleaner = resourcesCleaner;
        }

        private ComposedSceneLoadResult _current;
        private CurrentSceneHandlerLogger _logger;

        private IResourcesCleaner _resourcesCleaner;
        private ISceneUnloader _unloader;

        public void OnLoaded(ComposedSceneLoadResult loaded)
        {
            _current = loaded;

            _logger.OnLoaded(_current.Scenes.Count);
        }

        public async UniTask Unload()
        {
            if (_current == null)
            {
                _logger.OnNoCurrentSceneError();
                return;
            }

            _logger.OnUnload(_current.Scenes.Count);

            _current.OnUnload();

            await _unloader.Unload(_current.Scenes);
        }

        public async UniTask FinalizeUnloading()
        {
            await _resourcesCleaner.CleanUp();

            _logger.OnUnloadingFinalized();
        }
    }
}