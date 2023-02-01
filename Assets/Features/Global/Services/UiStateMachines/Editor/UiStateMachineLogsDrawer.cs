using Features.Common.ReadOnlyDictionaries.Editor;
using Features.Global.Services.UiStateMachines.Logs;
using UnityEditor;

namespace Features.Global.Services.UiStateMachines.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(UiStateMachineLogs))]
    public class UiStateMachineLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}