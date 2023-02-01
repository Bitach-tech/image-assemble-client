using Features.Common.ReadOnlyDictionaries.Editor;
using Features.GamePlay.Services.LevelCameras.Logs;
using UnityEditor;

namespace Features.GamePlay.Services.LevelCameras.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(LevelCameraLogs))]
    public class LevelCameraLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}