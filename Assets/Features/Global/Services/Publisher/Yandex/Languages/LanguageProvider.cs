using Global.Publisher.Abstract.Languages;
using Global.UI.Localizations.Definition;

namespace Global.Publisher.Yandex.Languages
{
    public class LanguageProvider : ILanguageProvider
    {
        private readonly LanguageInternal _internal = new();
        
        private bool _isLanguageReceived;
        private Language _selected;
        
        public Language GetLanguage()
        {
            if (_isLanguageReceived == true)
                return _selected;

            var raw = _internal.GetLanguage_Internal();
            _isLanguageReceived = true;

            return raw switch
            {
                "ru" => Language.Ru,
                "eng" => Language.Eng,
                _ => Language.Ru
            };
        }
    }
}