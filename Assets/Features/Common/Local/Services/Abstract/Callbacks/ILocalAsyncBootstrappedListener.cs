using Cysharp.Threading.Tasks;

namespace Features.Common.Local.Services.Abstract.Callbacks
{
    public interface ILocalAsyncBootstrappedListener
    {
        UniTask OnBootstrappedAsync();
    }
}