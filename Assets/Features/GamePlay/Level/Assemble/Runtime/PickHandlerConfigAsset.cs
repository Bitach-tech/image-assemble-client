using Features.GamePlay.Common.Paths;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.GamePlay.Level.Assemble.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GamePlayAssetsPaths.ConfigPrefix + "PickHandler",
        menuName = GamePlayAssetsPaths.PickHandler + "Config")]
    public class PickHandlerConfigAsset : ScriptableObject
    {
        [SerializeField] [Indent] [Min(0f)] private float _dropDistance;

        public float DropDistance => _dropDistance;
    }
}