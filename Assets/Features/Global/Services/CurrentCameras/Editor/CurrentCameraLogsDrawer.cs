using Features.Common.ReadOnlyDictionaries.Editor;
using Features.Global.Services.CurrentCameras.Logs;
using UnityEditor;

namespace Features.Global.Services.CurrentCameras.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(CurrentCameraLogs))]
    public class CurrentCameraLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}