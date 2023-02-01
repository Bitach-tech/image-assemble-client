using Features.GamePlay.Common.Paths;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.GamePlay.Services.Background.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GamePlayAssetsPaths.ConfigPrefix + "GameBackground",
        menuName = GamePlayAssetsPaths.GameBackground + "Config")]
    public class GameBackgroundConfigAsset : ScriptableObject
    {
        [SerializeField] [Min(0f)] private float _lineWidth;
        [SerializeField] [Min(0f)] private float _distanceBetweenLines;
        [SerializeField] [Min(0f)] private float _speed;

        public float LineWidth => _lineWidth;
        public float DistanceBetweenLines => _distanceBetweenLines;
        public float Speed => _speed;
    }
}