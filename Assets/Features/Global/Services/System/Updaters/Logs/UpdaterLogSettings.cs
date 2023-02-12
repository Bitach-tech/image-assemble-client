using Global.Loggers.Runtime;
using Global.Updaters.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Updaters.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = UpdaterRouter.LogsName,
        menuName = UpdaterRouter.LogsPath)]
    public class UpdaterLogSettings : LogSettings<UpdaterLogs, UpdaterLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}