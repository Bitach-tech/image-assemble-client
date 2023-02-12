using TMPro;
using UnityEngine;

namespace Global.UI.Localizations.Texts
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(TMP_Text))]
    public class LocalizedText : MonoBehaviour
    {
        [SerializeField] private LanguageTextData _data;
        
        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            
            _data.AttachText(OnLanguageChanged);
        }

        private void OnLanguageChanged(string text)
        {
            _text.text = text;
        }
    }
}