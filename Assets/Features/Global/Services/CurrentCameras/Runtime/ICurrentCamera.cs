using UnityEngine;

namespace Features.Global.Services.CurrentCameras.Runtime
{
    public interface ICurrentCamera
    {
        Camera Current { get; }

        void SetCamera(Camera current);
    }
}