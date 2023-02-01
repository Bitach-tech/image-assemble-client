using Features.Common.ReadOnlyDictionaries.Editor;
using Features.Global.Services.InputViews.ConstraintsStorage;
using UnityEditor;

namespace Features.Global.Services.InputViews.Editor
{
    [CustomPropertyDrawer(typeof(InputConstraintsDictionary))]
    public class InputConstraintsDictionaryDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}