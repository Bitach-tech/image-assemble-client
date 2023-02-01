using Features.Common.ReadOnlyDictionaries.Editor;
using Features.Global.Services.InputViews.Logs;
using UnityEditor;

namespace Features.Global.Services.InputViews.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(InputViewLogs))]
    public class InputViewLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}