using Global.ApplicationProxies.Common;
using Global.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.ApplicationProxies.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = ApplicationProxyRoutes.LogsName,
        menuName = ApplicationProxyRoutes.LogsPath)]
    public class ApplicationProxyLogSettings : LogSettings<ApplicationProxyLogs, ApplicationProxyLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}