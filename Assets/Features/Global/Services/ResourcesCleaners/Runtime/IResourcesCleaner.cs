using Cysharp.Threading.Tasks;

namespace Features.Global.Services.ResourcesCleaners.Runtime
{
    public interface IResourcesCleaner
    {
        UniTask CleanUp();
    }
}