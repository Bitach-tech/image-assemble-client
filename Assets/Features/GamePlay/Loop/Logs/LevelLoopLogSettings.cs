using Features.GamePlay.Common.Paths;
using Features.Global.Services.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.GamePlay.Loop.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = GamePlayAssetsPaths.LogsPrefix + "LevelLoop",
        menuName = GamePlayAssetsPaths.LevelLoop + "Logs")]
    public class LevelLoopLogSettings : LogSettings<LevelLoopLogs, LevelLoopLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}