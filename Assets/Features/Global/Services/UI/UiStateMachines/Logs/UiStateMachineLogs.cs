using System;
using Common.ReadOnlyDictionaries.Runtime;

namespace Global.Services.UI.UiStateMachines.Logs
{
    [Serializable]
    public class UiStateMachineLogs : ReadOnlyDictionary<UiStateMachineLogType, bool>
    {
    }
}