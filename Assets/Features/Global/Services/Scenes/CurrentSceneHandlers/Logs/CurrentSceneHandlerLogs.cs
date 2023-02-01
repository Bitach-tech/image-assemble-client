using System;
using Common.ReadOnlyDictionaries.Runtime;

namespace Global.Services.Scenes.CurrentSceneHandlers.Logs
{
    [Serializable]
    public class CurrentSceneHandlerLogs : ReadOnlyDictionary<CurrentSceneHandlerLogType, bool>
    {
    }
}