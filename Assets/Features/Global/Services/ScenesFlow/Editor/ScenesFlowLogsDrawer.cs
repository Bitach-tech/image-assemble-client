using Features.Common.ReadOnlyDictionaries.Editor;
using Features.Global.Services.ScenesFlow.Logs;
using UnityEditor;

namespace Features.Global.Services.ScenesFlow.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(ScenesFlowLogs))]
    public class ScenesFlowLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}