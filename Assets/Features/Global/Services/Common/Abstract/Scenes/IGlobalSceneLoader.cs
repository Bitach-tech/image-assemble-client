using Cysharp.Threading.Tasks;

namespace Features.Global.Services.Common.Abstract.Scenes
{
    public interface IGlobalSceneLoader
    {
        UniTask<InternalSceneLoadResult<T>> Load<T>(InternalScene<T> scene);
    }
}