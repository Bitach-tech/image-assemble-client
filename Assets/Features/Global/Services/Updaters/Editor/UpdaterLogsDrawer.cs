using Features.Common.ReadOnlyDictionaries.Editor;
using Features.Global.Services.Updaters.Logs;
using UnityEditor;

namespace Features.Global.Services.Updaters.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(UpdaterLogs))]
    public class UpdaterLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}