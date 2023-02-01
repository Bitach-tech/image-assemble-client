using Features.Common.ReadOnlyDictionaries.Editor;
using Features.Global.Services.ResourcesCleaners.Logs;
using UnityEditor;

namespace Features.Global.Services.ResourcesCleaners.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(ResourcesCleanerLogs))]
    public class ResourcesCleanerLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}