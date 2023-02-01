using System;
using Common.ReadOnlyDictionaries.Runtime;

namespace Global.Services.System.ResourcesCleaners.Logs
{
    [Serializable]
    public class ResourcesCleanerLogs : ReadOnlyDictionary<ResourcesCleanerLogType, bool>
    {
    }
}