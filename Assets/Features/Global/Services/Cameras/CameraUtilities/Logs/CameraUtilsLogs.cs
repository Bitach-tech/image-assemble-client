using System;
using Common.ReadOnlyDictionaries.Runtime;

namespace Global.Services.Cameras.CameraUtilities.Logs
{
    [Serializable]
    public class CameraUtilsLogs : ReadOnlyDictionary<CameraUtilsLogType, bool>
    {
    }
}