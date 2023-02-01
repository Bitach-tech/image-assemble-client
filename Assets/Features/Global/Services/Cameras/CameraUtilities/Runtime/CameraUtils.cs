using Global.Cameras.CameraUtilities.Logs;
using Global.Cameras.CurrentCameras.Runtime;
using UnityEngine;
using VContainer;

namespace Global.Cameras.CameraUtilities.Runtime
{
    public class CameraUtils : MonoBehaviour, ICameraUtils
    {
        [Inject]
        private void Construct(ICurrentCamera currentCamera, CameraUtilsLogger logger)
        {
            _currentCamera = currentCamera;
            _logger = logger;
        }

        private ICurrentCamera _currentCamera;
        private CameraUtilsLogger _logger;

        public Vector2 ScreenToWorld(Vector2 screen)
        {
            if (_currentCamera.Current == null)
            {
                _logger.OnNoCameraError();
                return Vector2.zero;
            }

            var world = (Vector2)_currentCamera.Current.ScreenToWorldPoint(screen);

            _logger.OnScreenToWorld(screen, world);

            return world;
        }
    }
}