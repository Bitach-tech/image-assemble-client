using System;
using Common.ReadOnlyDictionaries.Runtime;

namespace Global.ResourcesCleaners.Logs
{
    [Serializable]
    public class ResourcesCleanerLogs : ReadOnlyDictionary<ResourcesCleanerLogType, bool>
    {
    }
}