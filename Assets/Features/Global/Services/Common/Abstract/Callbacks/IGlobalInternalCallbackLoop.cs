using Cysharp.Threading.Tasks;

namespace Features.Global.Services.Common.Abstract.Callbacks
{
    public interface IGlobalInternalCallbackLoop
    {
        UniTask Run();
    }
}