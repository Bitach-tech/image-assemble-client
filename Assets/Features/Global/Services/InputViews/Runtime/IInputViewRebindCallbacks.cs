﻿namespace Features.Global.Services.InputViews.Runtime
{
    public interface IInputViewRebindCallbacks
    {
        void OnBeforeRebind();
        void OnAfterRebind();
    }
}