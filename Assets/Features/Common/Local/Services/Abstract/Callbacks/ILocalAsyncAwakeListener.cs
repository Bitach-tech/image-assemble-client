using Cysharp.Threading.Tasks;

namespace Features.Common.Local.Services.Abstract.Callbacks
{
    public interface ILocalAsyncAwakeListener
    {
        UniTask OnAwakeAsync();
    }
}