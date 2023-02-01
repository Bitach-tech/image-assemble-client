using System;
using Features.Common.ReadOnlyDictionaries.Runtime;

namespace Features.GamePlay.Loop.Logs
{
    [Serializable]
    public class LevelLoopLogs : ReadOnlyDictionary<LevelLoopLogType, bool>
    {
    }
}