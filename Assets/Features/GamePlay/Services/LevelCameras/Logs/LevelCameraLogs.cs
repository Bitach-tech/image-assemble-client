using System;
using Features.Common.ReadOnlyDictionaries.Runtime;

namespace Features.GamePlay.Services.LevelCameras.Logs
{
    [Serializable]
    public class LevelCameraLogs : ReadOnlyDictionary<LevelCameraLogType, bool>
    {
    }
}