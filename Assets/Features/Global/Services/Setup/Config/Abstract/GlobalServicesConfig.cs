using Global.Services.Setup.Abstract;
using UnityEngine;

namespace Global.Services.Setup.Config.Abstract
{
    public abstract class GlobalServicesConfig : ScriptableObject
    {
        public abstract GlobalServiceAsset[] GetAssets();
    }
}