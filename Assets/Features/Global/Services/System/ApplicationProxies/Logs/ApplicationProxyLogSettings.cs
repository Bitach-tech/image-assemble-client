using Global.Common;
using Global.Services.System.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.System.ApplicationProxies.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.LogsPrefix + "ApplicationProxy",
        menuName = GlobalAssetsPaths.ApplicationProxy + "Logs")]
    public class ApplicationProxyLogSettings : LogSettings<ApplicationProxyLogs, ApplicationProxyLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}