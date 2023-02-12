using Common.ReadOnlyDictionaries.Editor;
using Global.MessageBrokers.Logs;
using UnityEditor;

namespace Global.MessageBrokers.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(MessageBrokerLogs))]
    public class MessageBrokerLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}