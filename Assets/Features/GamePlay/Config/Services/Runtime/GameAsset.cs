using Common.Local.ComposedSceneConfig;
using Common.Local.Services.Abstract;
using GamePlay.Background.Runtime;
using GamePlay.Common.Paths;
using GamePlay.Common.Scope;
using GamePlay.LevelCameras.Runtime;
using GamePlay.Loop.Runtime;
using GamePlay.Menu.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Config.Services.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "Level", menuName = GamePlayAssetsPaths.Root + "Scene")]
    public class GameAsset : ComposedSceneAsset
    {
        [SerializeField] private LevelCameraAsset _levelCamera;
        [SerializeField] private LevelLoopAsset _levelLoop;
        [SerializeField] private MenuUIAsset _menuUi;
        [SerializeField] private GameBackgroundAsset _background;

        [SerializeField] private LevelScope _scopePrefab;

        protected override ILocalServiceFactory[] GetFactories()
        {
            var services = new ILocalServiceFactory[]
            {
                _levelCamera,
                _levelLoop,
            };

            return services;
        }

        protected override ILocalServiceAsyncFactory[] GetAsyncFactories()
        {
            var services = new ILocalServiceAsyncFactory[]
            {
                _menuUi,
                _background
            };

            return services;
        }

        protected override LifetimeScope AssignScope()
        {
            return _scopePrefab;
        }
    }
}