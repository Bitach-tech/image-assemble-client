using Global.Common;
using Global.Services.System.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.UI.UiStateMachines.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.LogsPrefix + "UiStateMachine",
        menuName = GlobalAssetsPaths.UiStateMachine + "Logs")]
    public class UiStateMachineLogSettings : LogSettings<UiStateMachineLogs, UiStateMachineLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}