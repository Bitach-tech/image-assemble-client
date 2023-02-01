using Features.Global.Common;
using Features.Global.Services.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.Global.GameLoops.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.LogsPrefix + "GameLoop",
        menuName = GlobalAssetsPaths.GameLoop + "Logs")]
    public class GameLoopLogSettings : LogSettings<GameLoopLogs, GameLoopLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}