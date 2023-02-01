using Global.Common;
using Global.Services.System.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.System.MessageBrokers.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.LogsPrefix + "MessageBrokerLog",
        menuName = GlobalAssetsPaths.MessageBroker + "Logs")]
    public class MessageBrokerLogSettings : LogSettings<MessageBrokerLogs, MessageBrokerLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}