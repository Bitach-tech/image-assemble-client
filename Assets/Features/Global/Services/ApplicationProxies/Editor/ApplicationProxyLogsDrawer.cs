using Features.Common.ReadOnlyDictionaries.Editor;
using Features.Global.Services.ApplicationProxies.Logs;
using UnityEditor;

namespace Features.Global.Services.ApplicationProxies.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(ApplicationProxyLogs))]
    public class ApplicationProxyLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}