using UnityEngine;

namespace Features.Global.Services.CameraUtilities.Runtime
{
    public interface ICameraUtils
    {
        Vector2 ScreenToWorld(Vector2 screen);
    }
}