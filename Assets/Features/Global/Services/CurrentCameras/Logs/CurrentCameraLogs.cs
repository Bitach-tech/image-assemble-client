using System;
using Features.Common.ReadOnlyDictionaries.Runtime;

namespace Features.Global.Services.CurrentCameras.Logs
{
    [Serializable]
    public class CurrentCameraLogs : ReadOnlyDictionary<CurrentCameraLogType, bool>
    {
    }
}