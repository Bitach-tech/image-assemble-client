using Cysharp.Threading.Tasks;

namespace Global.Services.Setup.Abstract.Scenes
{
    public interface IGlobalSceneLoader
    {
        UniTask<InternalSceneLoadResult<T>> Load<T>(InternalScene<T> scene);
    }
}