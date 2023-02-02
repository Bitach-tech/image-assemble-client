using GamePlay.Common.Paths;
using GamePlay.Level.ImageStorage.Common;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace GamePlay.Level.ImageStorage.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ImageStorageRoutes.ImageName,
        menuName = ImageStorageRoutes.ImagePath)]
    public class LevelImage : ScriptableObject
    {
        [SerializeField] private Sprite[] _level0;
        [SerializeField] private Sprite[] _level1;
        [SerializeField] private Sprite[] _level2;
        [SerializeField] private Sprite[] _level3;

        public void SetLevel0(Sprite[] sprites)
        {
            _level0 = sprites;
        }

        public void SetLevel1(Sprite[] sprites)
        {
            _level1 = sprites;
        }
        public void SetLevel2(Sprite[] sprites)
        {
            _level2 = sprites;
        }
        
        public void SetLevel3(Sprite[] sprites)
        {
            _level3 = sprites;
        }
    }
}