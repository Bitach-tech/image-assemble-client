using System;
using Features.Common.ReadOnlyDictionaries.Runtime;

namespace Features.Global.Services.ApplicationProxies.Logs
{
    [Serializable]
    public class ApplicationProxyLogs : ReadOnlyDictionary<ApplicationProxyLogType, bool>
    {
    }
}