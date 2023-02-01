using UnityEngine;

namespace Features.Common.Local.Services.Abstract
{
    public interface ILocalServiceBinder
    {
        void AddToModules(MonoBehaviour service);
    }
}