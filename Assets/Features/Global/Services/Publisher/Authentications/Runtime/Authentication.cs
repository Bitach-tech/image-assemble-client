using Plugins.YandexGames.Runtime;
using UnityEngine;

namespace Global.Publisher.Authentications.Runtime
{
    [DisallowMultipleComponent]
    public class Authentication : MonoBehaviour, IAuthentication
    {
        public void Authenticate()
        {
            YandexSDK.instance.Authenticate();
        }
    }
}