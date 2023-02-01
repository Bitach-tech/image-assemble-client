using UnityEngine.SceneManagement;

namespace Features.Global.Services.ScenesFlow.Handling.Result
{
    public class TypedSceneLoadResult<T> : SceneLoadResult
    {
        public TypedSceneLoadResult(Scene scene, T searched) : base(scene)
        {
            Searched = searched;
        }

        public readonly T Searched;
    }
}