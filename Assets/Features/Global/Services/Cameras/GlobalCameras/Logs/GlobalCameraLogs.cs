using System;
using Common.ReadOnlyDictionaries.Runtime;

namespace Global.Services.Cameras.GlobalCameras.Logs
{
    [Serializable]
    public class GlobalCameraLogs : ReadOnlyDictionary<GlobalCameraLogType, bool>
    {
    }
}