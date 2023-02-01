using Global.Services.Setup.Abstract.Callbacks;

namespace Global.Services.Setup.Abstract
{
    public interface IGlobalCallbacks
    {
        void Listen(object listener);
        void AddInternalCallbackLoop(IGlobalInternalCallbackLoop callbackLoop);
    }
}