using GamePlay.Level.ImageStorage.Common;
using Sirenix.OdinInspector;
using UnityEngine;

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
        
        [SerializeField] private Sprite _preview;

        public Sprite[] Level0 => _level0;
        public Sprite[] Level1 => _level1;
        public Sprite[] Level2 => _level2;
        public Sprite[] Level3 => _level3;
        public Sprite Preview => _preview;

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

        public void SetPreview(Sprite sprite)
        {
            _preview = sprite;
        }
    }
}