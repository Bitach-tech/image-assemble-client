using Features.Common.ReadOnlyDictionaries.Editor;
using Features.Global.Services.CurrentSceneHandlers.Logs;
using UnityEditor;

namespace Features.Global.Services.CurrentSceneHandlers.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(CurrentSceneHandlerLogs))]
    public class CurrentSceneHandlerLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}