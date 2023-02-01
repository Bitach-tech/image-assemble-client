using Features.Common.ReadOnlyDictionaries.Editor;
using Features.Global.Services.MessageBrokers.Logs;
using UnityEditor;

namespace Features.Global.Services.MessageBrokers.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(MessageBrokerLogs))]
    public class MessageBrokerLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}