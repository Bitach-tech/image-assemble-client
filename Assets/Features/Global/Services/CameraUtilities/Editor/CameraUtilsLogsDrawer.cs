using Features.Common.ReadOnlyDictionaries.Editor;
using Features.Global.Services.CameraUtilities.Logs;
using UnityEditor;

namespace Features.Global.Services.CameraUtilities.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(CameraUtilsLogs))]
    public class CameraUtilsLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}