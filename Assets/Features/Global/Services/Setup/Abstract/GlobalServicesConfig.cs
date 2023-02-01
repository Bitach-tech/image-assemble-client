using Global.Setup.Service;
using UnityEngine;

namespace Global.Setup.Abstract
{
    public abstract class GlobalServicesConfig : ScriptableObject
    {
        public abstract GlobalServiceAsset[] GetAssets();
    }
}