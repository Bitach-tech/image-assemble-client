using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;
using GamePlay.Loop.Difficulties;

namespace GamePlay.Level.Assemble.Runtime
{
    [Serializable]
    public class ImageViewDictionary : ReadOnlyDictionary<LevelDifficulty, ImageView>
    {
    }
}