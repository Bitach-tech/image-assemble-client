using Common.ReadOnlyDictionaries.Editor;
using Global.ApplicationProxies.Logs;
using UnityEditor;

namespace Global.ApplicationProxies.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(ApplicationProxyLogs))]
    public class ApplicationProxyLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}