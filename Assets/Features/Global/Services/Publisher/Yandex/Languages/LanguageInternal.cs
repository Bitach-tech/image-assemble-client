﻿using System.Runtime.InteropServices;

namespace Global.Publisher.Yandex.Languages
{
    public class LanguageInternal
    {
        [DllImport("__Internal")]
        private static extern string GetLang();

        public string GetLanguage_Internal()
        {
            return GetLang();
        }
    }
}