using Cysharp.Threading.Tasks;

namespace Global.Setup.Service.Scenes
{
    public interface IGlobalSceneLoader
    {
        UniTask<InternalSceneLoadResult<T>> Load<T>(InternalScene<T> scene);
    }
}