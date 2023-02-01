﻿using System.Collections.Generic;
using Features.Global.Services.InputViews.Constraints;

namespace Features.Global.Services.InputViews.ConstraintsStorage
{
    public interface IInputConstraintsStorage
    {
        bool this[InputConstraints key] { get; }

        void Add(IReadOnlyDictionary<InputConstraints, bool> constraint);
        void Remove(IReadOnlyDictionary<InputConstraints, bool> constraint);
    }
}