using Features.Common.DiContainer.Abstract;

namespace Features.Common.Local.Services.Abstract.Callbacks
{
    public interface ILocalContainerBuildListener
    {
        void OnContainerBuild(IDependencyRegister builder);
    }
}