using UnityEngine;

namespace Global.Services.Setup.Abstract
{
    public interface IServiceBinder
    {
        void AddToModules(MonoBehaviour service);
        void ListenCallbacks(object service);
    }
}