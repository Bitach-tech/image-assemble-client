using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Features.Global.Services.ScenesFlow.Handling.Result;

namespace Features.Global.Services.ScenesFlow.Runtime.Abstract
{
    public interface ISceneUnloader
    {
        UniTask Unload(SceneLoadResult result);

        UniTask Unload(IReadOnlyList<SceneLoadResult> scenes);
    }
}