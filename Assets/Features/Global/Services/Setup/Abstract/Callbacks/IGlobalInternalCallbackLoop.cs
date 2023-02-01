using Cysharp.Threading.Tasks;

namespace Global.Services.Setup.Abstract.Callbacks
{
    public interface IGlobalInternalCallbackLoop
    {
        UniTask Run();
    }
}