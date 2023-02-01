using System;
using Common.ReadOnlyDictionaries.Runtime;
using Global.Services.Inputs.Constranits.Definition;

namespace Global.Services.Inputs.Constranits.Storage
{
    [Serializable]
    public class InputConstraintsDictionary : ReadOnlyDictionary<InputConstraints, bool>
    {
    }
}