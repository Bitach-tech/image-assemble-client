using System.Collections.Generic;
using Global.Common;
using Global.Services.Inputs.Constranits.Definition;
using Global.Services.Inputs.Constranits.Storage;
using UnityEngine;

namespace Global.Services.UI.UiStateMachines.Runtime
{
    [CreateAssetMenu(fileName = "UiConstraints_", menuName = GlobalAssetsPaths.UiStateMachine + "Constraints")]
    public class UiConstraints : ScriptableObject
    {
        [SerializeField] private InputConstraintsDictionary _input;

        public IReadOnlyDictionary<InputConstraints, bool> Input => _input;
    }
}