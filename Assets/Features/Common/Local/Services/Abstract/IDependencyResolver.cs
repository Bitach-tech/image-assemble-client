using VContainer;

namespace Features.Common.Local.Services.Abstract
{
    public interface IDependencyResolver
    {
        void Resolve(IObjectResolver resolver);
    }
}