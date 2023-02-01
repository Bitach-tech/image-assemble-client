using System;
using Features.Common.ReadOnlyDictionaries.Runtime;

namespace Features.Global.Services.CameraUtilities.Logs
{
    [Serializable]
    public class CameraUtilsLogs : ReadOnlyDictionary<CameraUtilsLogType, bool>
    {
    }
}