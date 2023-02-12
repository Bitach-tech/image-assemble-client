using Common.ReadOnlyDictionaries.Editor;
using Global.ResourcesCleaners.Logs;
using UnityEditor;

namespace Global.ResourcesCleaners.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(ResourcesCleanerLogs))]
    public class ResourcesCleanerLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}