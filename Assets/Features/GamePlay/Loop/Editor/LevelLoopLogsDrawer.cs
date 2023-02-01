using Features.Common.ReadOnlyDictionaries.Editor;
using Features.GamePlay.Loop.Logs;
using UnityEditor;

namespace Features.GamePlay.Loop.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(LevelLoopLogs))]
    public class LevelLoopLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}