using UnityEngine;

namespace Global.ApplicationProxies.Runtime
{
    [DisallowMultipleComponent]
    public class ApplicationProxy : IApplicationFlow
    {
        public void Quit()
        {
            Application.Quit();
        }
    }
}