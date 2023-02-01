using System;
using Features.Common.ReadOnlyDictionaries.Runtime;

namespace Features.Global.Services.InputViews.Logs
{
    [Serializable]
    public class InputViewLogs : ReadOnlyDictionary<InputViewLogType, bool>
    {
    }
}