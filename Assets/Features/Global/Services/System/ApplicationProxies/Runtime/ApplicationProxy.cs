using UnityEngine;

namespace Global.System.ApplicationProxies.Runtime
{
    [DisallowMultipleComponent]
    public class ApplicationProxy : MonoBehaviour, IApplicationFlow
    {
        public void Quit()
        {
            Application.Quit();
        }
    }
}