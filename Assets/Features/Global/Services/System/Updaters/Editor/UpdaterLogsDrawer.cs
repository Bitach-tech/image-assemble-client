using Common.ReadOnlyDictionaries.Editor;
using Global.Updaters.Logs;
using UnityEditor;

namespace Global.Updaters.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(UpdaterLogs))]
    public class UpdaterLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}