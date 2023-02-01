﻿using UnityEngine;

namespace Features.Global.Services.ApplicationProxies.Runtime
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