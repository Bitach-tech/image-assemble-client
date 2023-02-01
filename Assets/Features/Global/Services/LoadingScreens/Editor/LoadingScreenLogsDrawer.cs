using Features.Common.ReadOnlyDictionaries.Editor;
using Features.Global.Services.LoadingScreens.Logs;
using UnityEditor;

namespace Features.Global.Services.LoadingScreens.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(LoadingScreenLogs))]
    public class LoadingScreenLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}