using Features.Global.Services.Common.Abstract.Callbacks;

namespace Features.Global.Services.Common.Abstract
{
    public interface IGlobalCallbacks
    {
        void Listen(object listener);
        void AddInternalCallbackLoop(IGlobalInternalCallbackLoop callbackLoop);
    }
}