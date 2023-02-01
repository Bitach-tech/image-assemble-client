using System.Collections.Generic;
using Features.Common.Local.ComposedSceneConfig;
using Features.Common.Local.Services.Abstract;
using Features.GamePlay.Common.Paths;
using Features.GamePlay.Loop.Runtime;
using Features.GamePlay.Menu.Runtime;
using Features.GamePlay.Services.Background.Runtime;
using Features.GamePlay.Services.Common.Scope;
using Features.GamePlay.Services.LevelCameras.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer.Unity;

namespace Features.GamePlay.Config.Services.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "Level", menuName = GamePlayAssetsPaths.Root + "Scene")]
    public class GameAsset : ComposedSceneAsset
    {
        [SerializeField] private LevelCameraAsset _levelCamera;
        [SerializeField] private LevelLoopAsset _levelLoop;
        [SerializeField] private MenuUIAsset _menuUi;
        [SerializeField] private GameBackgroundAsset _background;
        // [SerializeField] private ToolHandlerAsset _toolHandler;
        // [SerializeField] private PaintCanvasAsset _canvas;
        // [SerializeField] private ColorSelectionUiAsset _colorSelectionUI;
        // [SerializeField] private ToolSelectionUiAsset _toolSelectionUI;
        // [SerializeField] private ImageStorageAsset _imageStorage;
        // [SerializeField] private PaintLoopAsset _paintLoop;

        [SerializeField] private LevelScope _scopePrefab;

        protected override LocalServiceAsset[] AssignServices()
        {
            var list = new List<LocalServiceAsset>
            {
                _levelCamera,
                _levelLoop,
                _menuUi,
                _background
                // _toolHandler,
                // _canvas,
                // _colorSelectionUI,
                // _toolSelectionUI,
                // _imageStorage,
                // _paintLoop
            };

            return list.ToArray();
        }

        protected override LifetimeScope AssignScope()
        {
            return _scopePrefab;
        }
    }
}