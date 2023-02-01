using System.Collections.Generic;
using Features.Global.Common;
using Features.Global.Services.InputViews.Constraints;
using Features.Global.Services.InputViews.ConstraintsStorage;
using UnityEngine;

namespace Features.Global.Services.UiStateMachines.Runtime
{
    [CreateAssetMenu(fileName = "UiConstraints_", menuName = GlobalAssetsPaths.UiStateMachine + "Constraints")]
    public class UiConstraints : ScriptableObject
    {
        [SerializeField] private InputConstraintsDictionary _input;

        public IReadOnlyDictionary<InputConstraints, bool> Input => _input;
    }
}