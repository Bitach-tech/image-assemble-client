using System;
using Common.ReadOnlyDictionaries.Runtime;

namespace Global.Services.Inputs.View.Logs
{
    [Serializable]
    public class InputViewLogs : ReadOnlyDictionary<InputViewLogType, bool>
    {
    }
}