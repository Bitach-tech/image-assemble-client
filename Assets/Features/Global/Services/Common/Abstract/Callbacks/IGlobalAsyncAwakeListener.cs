using Cysharp.Threading.Tasks;

namespace Features.Global.Services.Common.Abstract.Callbacks
{
    public interface IGlobalAsyncAwakeListener
    {
        UniTask OnAwakeAsync();
    }
}