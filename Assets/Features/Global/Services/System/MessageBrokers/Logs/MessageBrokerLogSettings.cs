using Global.Loggers.Runtime;
using Global.MessageBrokers.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.MessageBrokers.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = MessageBrokerRouter.LogsName,
        menuName = MessageBrokerRouter.LogsPath)]
    public class MessageBrokerLogSettings : LogSettings<MessageBrokerLogs, MessageBrokerLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}