using System;
using System.Collections.Generic;
using Features.Common.NestedScriptableObjects.Attributes;
using Features.Global.Services.Loggers.Runtime.Headers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.Global.Services.Loggers.Runtime
{
    [Serializable]
    public class LogParameters
    {
        [SerializeField] private bool _isMessageColored;

        [ShowIf("_isMessageColored")] [SerializeField] [ColorPalette]
        private Color _color;

        [SerializeField] [NestedScriptableObjectList]
        private List<LoggerHeader> _headers = new();

        public bool IsMessageColored => _isMessageColored;
        public string Color => ColorUtility.ToHtmlStringRGB(_color);

        public IReadOnlyList<LoggerHeader> Headers => _headers;
    }
}