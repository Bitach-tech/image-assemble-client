using UnityEngine;

namespace Global.Services.Setup.Abstract
{
    public interface IGlobalServiceBinder
    {
        void AddToModules(MonoBehaviour service);
    }
}