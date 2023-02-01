using Features.GamePlay.Common.Paths;
using Features.Global.Services.Loggers.Runtime;
using UnityEngine;

namespace Features.GamePlay.Services.LevelCameras.Logs
{
    [CreateAssetMenu(fileName = GamePlayAssetsPaths.LogsPrefix + "LevelCamera",
        menuName = GamePlayAssetsPaths.LevelCamera + "Logs")]
    public class LevelCameraLogSettings : LogSettings<LevelCameraLogs, LevelCameraLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}