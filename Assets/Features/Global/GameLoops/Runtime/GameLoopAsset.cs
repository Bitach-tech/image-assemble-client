using Features.Common.DiContainer.Abstract;
using Features.Global.Common;
using Features.Global.GameLoops.Abstract;
using Features.Global.GameLoops.Logs;
using Features.Global.Services.Common.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.Global.GameLoops.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.ServicePrefix + "Global",
        menuName = GlobalAssetsPaths.GameLoop + "Service")]
    public class GameLoopAsset : GlobalGameLoopAsset
    {
        [SerializeField] [Indent] private GameLoopLogSettings _logSettings;

        [SerializeField] [Indent] private GameLoop _prefab;

        public override GlobalGameLoop Create(IDependencyRegister register, IGlobalServiceBinder binder)
        {
            var gameLoop = Instantiate(_prefab);
            gameLoop.name = "GameLoop";

            register.Register<GameLoopLogger>()
                .WithParameter(_logSettings);

            register.RegisterComponent(gameLoop)
                .AsImplementedInterfaces()
                .AsSelfResolvable();

            binder.AddToModules(gameLoop);

            return gameLoop;
        }
    }
}