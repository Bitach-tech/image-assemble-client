using UnityEngine.SceneManagement;

namespace Features.Global.Services.ScenesFlow.Handling.Result
{
    public abstract class SceneLoadResult
    {
        public SceneLoadResult(Scene scene)
        {
            Scene = scene;
        }

        public readonly Scene Scene;
    }
}