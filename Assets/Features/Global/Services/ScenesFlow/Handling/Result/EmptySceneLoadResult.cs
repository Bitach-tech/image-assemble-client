using UnityEngine.SceneManagement;

namespace Features.Global.Services.ScenesFlow.Handling.Result
{
    public class EmptySceneLoadResult : SceneLoadResult
    {
        public EmptySceneLoadResult(Scene scene) : base(scene)
        {
        }
    }
}