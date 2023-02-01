using System;
using Features.Common.ReadOnlyDictionaries.Runtime;
using Features.Global.Services.InputViews.Constraints;

namespace Features.Global.Services.InputViews.ConstraintsStorage
{
    [Serializable]
    public class InputConstraintsDictionary : ReadOnlyDictionary<InputConstraints, bool>
    {
    }
}