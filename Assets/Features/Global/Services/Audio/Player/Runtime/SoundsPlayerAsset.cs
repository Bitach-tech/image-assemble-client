using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Audio.Player.Common;
using Global.Setup.Service;
using Global.Setup.Service.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Audio.Player.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AudioRoutes.ServiceName,
        menuName = AudioRoutes.ServicePath)]
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