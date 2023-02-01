using Cysharp.Threading.Tasks;

namespace Features.Global.Services.Common.Abstract.Callbacks
{
    public interface IGlobalAsyncBootstrapListener
    {
        UniTask OnBootstrapAsync();
    }
}