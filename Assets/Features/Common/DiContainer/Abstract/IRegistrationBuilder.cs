using VContainer;

namespace Features.Common.DiContainer.Abstract
{
    public interface IRegistrationBuilder
    {
        void Register(IContainerBuilder builder);
        void Resolve(IObjectResolver resolver);
        void ResolveWithCallbacks(IObjectResolver resolver, ICallbackRegister callbackRegister);
    }
}