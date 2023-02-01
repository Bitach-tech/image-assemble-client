using System;
using Features.Common.ReadOnlyDictionaries.Runtime;

namespace Features.Global.GameLoops.Logs
{
    [Serializable]
    public class GameLoopLogs : ReadOnlyDictionary<GameLoopLogType, bool>
    {
    }
}