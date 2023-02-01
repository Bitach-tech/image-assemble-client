using System;
using Features.Common.ReadOnlyDictionaries.Runtime;

namespace Features.Global.Services.MessageBrokers.Logs
{
    [Serializable]
    public class MessageBrokerLogs : ReadOnlyDictionary<MessageBrokerLogType, bool>
    {
    }
}