using System;
using Common.ReadOnlyDictionaries.Runtime;

namespace Global.ApplicationProxies.Logs
{
    [Serializable]
    public class ApplicationProxyLogs : ReadOnlyDictionary<ApplicationProxyLogType, bool>
    {
    }
}