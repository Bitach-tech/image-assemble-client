using System;
using Features.Common.ReadOnlyDictionaries.Runtime;

namespace Features.Global.Services.UiStateMachines.Logs
{
    [Serializable]
    public class UiStateMachineLogs : ReadOnlyDictionary<UiStateMachineLogType, bool>
    {
    }
}