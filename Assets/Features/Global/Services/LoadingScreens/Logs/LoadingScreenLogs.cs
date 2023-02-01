using System;
using Features.Common.ReadOnlyDictionaries.Runtime;

namespace Features.Global.Services.LoadingScreens.Logs
{
    [Serializable]
    public class LoadingScreenLogs : ReadOnlyDictionary<LoadingScreenLogType, bool>
    {
    }
}