using Global.Common;
using Global.Services.System.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.Cameras.CameraUtilities.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.LogsPrefix + "CurrentCameraUtils",
        menuName = GlobalAssetsPaths.CameraUtils + "Logs")]
    public class CameraUtilsLogSettings : LogSettings<CameraUtilsLogs, CameraUtilsLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}