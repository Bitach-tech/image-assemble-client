using Features.Common.ReadOnlyDictionaries.Editor;
using Features.Global.Services.GlobalCameras.Logs;
using UnityEditor;

namespace Features.Global.Services.GlobalCameras.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(GlobalCameraLogs))]
    public class GlobalCameraLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}