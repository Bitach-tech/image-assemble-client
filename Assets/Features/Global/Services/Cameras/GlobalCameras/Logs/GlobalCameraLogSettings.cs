using Global.Common;
using Global.Services.System.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.Cameras.GlobalCameras.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.LogsPrefix + "GlobalCamera",
        menuName = GlobalAssetsPaths.GlobalCamera + "Logs")]
    public class GlobalCameraLogSettings : LogSettings<GlobalCameraLogs, GlobalCameraLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}