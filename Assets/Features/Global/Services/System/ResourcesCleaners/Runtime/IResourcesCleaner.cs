using Cysharp.Threading.Tasks;

namespace Global.ResourcesCleaners.Runtime
{
    public interface IResourcesCleaner
    {
        UniTask CleanUp();
    }
}