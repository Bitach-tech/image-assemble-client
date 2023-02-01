using VContainer;

namespace Features.Common.DiContainer.Abstract
{
    public interface IInjectionBuilder
    {
        void Inject(IObjectResolver resolver);
    }
}