using Features.Common.UI.UniversalPlates.Runtime.Abstract;
using Features.Common.UI.UniversalPlates.Setup.Colors;
using TMPro;
using UnityEngine;

namespace Features.Common.UI.UniversalPlates.Runtime.Plate
{
    [DisallowMultipleComponent]
    public class UniversalTextColorSetter : UniversalProperty
    {
        [SerializeField] private UniversalTextColorConfig _color;

        [SerializeField] private TMP_Text _text;

        public override void UpdateProperty()
        {
            if (_color == null || _text == null)
                return;

            _text.color = _color.Value;
        }
    }
}