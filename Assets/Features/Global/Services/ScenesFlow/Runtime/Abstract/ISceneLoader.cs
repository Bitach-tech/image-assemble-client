using Cysharp.Threading.Tasks;
using Features.Global.Services.ScenesFlow.Handling.Data;
using Features.Global.Services.ScenesFlow.Handling.Result;

namespace Features.Global.Services.ScenesFlow.Runtime.Abstract
{
    public interface ISceneLoader
    {
        UniTask<T> Load<T>(SceneLoadData<T> scene) where T : SceneLoadResult;
    }
}