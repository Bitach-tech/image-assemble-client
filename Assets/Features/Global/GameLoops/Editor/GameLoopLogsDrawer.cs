using Features.Common.ReadOnlyDictionaries.Editor;
using Features.Global.GameLoops.Logs;
using UnityEditor;

namespace Features.Global.GameLoops.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(GameLoopLogs))]
    public class GameLoopLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}