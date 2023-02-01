using System;
using Features.Common.ReadOnlyDictionaries.Runtime;

namespace Features.Global.Services.ScenesFlow.Logs
{
    [Serializable]
    public class ScenesFlowLogs : ReadOnlyDictionary<ScenesFlowLogType, bool>
    {
    }
}