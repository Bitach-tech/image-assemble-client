using UnityEngine;

namespace Features.Global.Services.Common.Abstract
{
    public interface IGlobalServiceBinder
    {
        void AddToModules(MonoBehaviour service);
    }
}