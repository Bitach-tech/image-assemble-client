using System;
using Features.Common.ReadOnlyDictionaries.Runtime;

namespace Features.Global.Services.ResourcesCleaners.Logs
{
    [Serializable]
    public class ResourcesCleanerLogs : ReadOnlyDictionary<ResourcesCleanerLogType, bool>
    {
    }
}