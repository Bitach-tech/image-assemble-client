using Cysharp.Threading.Tasks;
using Features.Common.Local.ComposedSceneConfig;

namespace Features.Global.Services.CurrentSceneHandlers.Runtime
{
    public interface ICurrentSceneHandler
    {
        public void OnLoaded(ComposedSceneLoadResult loaded);

        public UniTask Unload();

        public UniTask FinalizeUnloading();
    }
}