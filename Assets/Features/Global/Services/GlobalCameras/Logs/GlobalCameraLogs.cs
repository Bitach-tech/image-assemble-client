using System;
using Features.Common.ReadOnlyDictionaries.Runtime;

namespace Features.Global.Services.GlobalCameras.Logs
{
    [Serializable]
    public class GlobalCameraLogs : ReadOnlyDictionary<GlobalCameraLogType, bool>
    {
    }
}