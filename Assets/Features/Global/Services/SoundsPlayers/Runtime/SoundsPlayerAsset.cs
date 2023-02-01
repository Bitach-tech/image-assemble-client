using Cysharp.Threading.Tasks;
using Features.Common.DiContainer.Abstract;
using Features.Global.Common;
using Features.Global.Services.Common.Abstract;
using Features.Global.Services.Common.Abstract.Scenes;
using UnityEngine;

namespace Features.Global.Services.SoundsPlayers.Runtime
{
    [CreateAssetMenu(fileName = GlobalAssetsPaths.ServicePrefix + "SoundsPlayer",
        menuName = GlobalAssetsPaths.SoundsPlayer + "Service")]
    public class SoundsPlayerAsset : GlobalServiceAsset
    {
        [SerializeField] private SoundsPlayer _prefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks)
        {
            var player = Instantiate(_prefab);
            player.name = "SoundsPlayer";

            var trigger = player.GetComponent<SoundsTrigger>();
            var switcher = player.GetComponent<SoundsVolumeSwitcher>();

            callbacks.Listen(trigger);
            callbacks.Listen(switcher);
            serviceBinder.AddToModules(player);
        }
    }
}