using System;
using Features.Common.ReadOnlyDictionaries.Runtime;

namespace Features.Global.Services.CurrentSceneHandlers.Logs
{
    [Serializable]
    public class CurrentSceneHandlerLogs : ReadOnlyDictionary<CurrentSceneHandlerLogType, bool>
    {
    }
}