using UnityEngine.SceneManagement;

namespace Features.Global.Services.Common.Abstract.Scenes
{
    public class InternalSceneLoadResult<T>
    {
        public InternalSceneLoadResult(Scene instance, T searched)
        {
            Instance = instance;
            Searched = searched;
        }

        public readonly Scene Instance;
        public readonly T Searched;
    }
}