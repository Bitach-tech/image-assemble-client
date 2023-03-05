using Common.Serialization.ReadOnlyDictionaries.Editor;
using GamePlay.Level.Assemble.Runtime;
using UnityEditor;

namespace GamePlay.Level.Assemble.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(ImageViewDictionary))]
    public class ImageViewDictionaryDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}