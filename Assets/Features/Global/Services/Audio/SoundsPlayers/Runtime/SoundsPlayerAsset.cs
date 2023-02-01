using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Common;
using Global.Services.Setup.Abstract;
using Global.Services.Setup.Abstract.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.Audio.SoundsPlayers.Runtime
{
    [InlineEditor]
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