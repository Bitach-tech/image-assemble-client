using System;
using Features.Common.UI.UniversalPlates.Setup.Colors;
using UnityEngine;

namespace Features.Common.UI.UniversalPlates.Setup.Common
{
    [Serializable]
    public class TextPlateConfig
    {
        [SerializeField] private UniversalPlateColorConfig _plate;
        [SerializeField] private UniversalTextColorConfig _text;
    }
}