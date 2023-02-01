using System;
using Common.ReadOnlyDictionaries.Runtime;

namespace Global.Services.System.MessageBrokers.Logs
{
    [Serializable]
    public class MessageBrokerLogs : ReadOnlyDictionary<MessageBrokerLogType, bool>
    {
    }
}