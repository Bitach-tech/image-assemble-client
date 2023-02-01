using Global.Common;
using Global.Services.System.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.System.Updaters.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.LogsPrefix + "Updater",
        menuName = GlobalAssetsPaths.Updater + "Logs")]
    public class UpdaterLogSettings : LogSettings<UpdaterLogs, UpdaterLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}