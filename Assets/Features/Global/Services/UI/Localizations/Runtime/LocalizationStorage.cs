using System.Collections.Generic;
using System.Collections.ObjectModel;
using Global.UI.Localizations.Common;
using Global.UI.Localizations.Texts;
using UnityEngine;

namespace Global.UI.Localizations.Runtime
{
    [CreateAssetMenu(fileName = LocalizationRoutes.StorageName, menuName = LocalizationRoutes.StoragePath)]
    public class LocalizationStorage : ScriptableObject, ILocalizationStorage
    {
        [SerializeField] private LanguageTextData[] _datas;
        
        public IReadOnlyList<LanguageTextData> GetDatas()
        {
            var result = new ReadOnlyCollection<LanguageTextData>(_datas);

            return result;
        }
    }
}