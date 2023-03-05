using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Global.UI.UiStateMachines.Logs
{
    [Serializable]
    public class UiStateMachineLogs : ReadOnlyDictionary<UiStateMachineLogType, bool>
    {
    }
}