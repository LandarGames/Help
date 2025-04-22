using System;
using UnityEngine;

namespace Localization
{
    public class Localization
    {
        public static Localization Instance { get; private set; }

        public event Action<ELanguage> OnChangeLanguage;

        public ELanguage Language { get; private set; }

        [SerializeField] private ELanguage startLanguage;

        public Localization()
        {
            Instance = this;

            LoadLanguage();
        }

        public void ChangeLanguage(ELanguage language)
        {
            Language = language;

            OnChangeLanguage?.Invoke(Language);
            SaveLanguage(language);
        }

        public void ChangeLanguage(int languageId)
        {
            var language = (ELanguage)languageId;

            ChangeLanguage(language);
        }

        private void SaveLanguage(ELanguage language)
        {
            SaveService.SetInt("Localization_Language", (int)language);
        }

        private void LoadLanguage()
        {
            var language = SaveService.GetInt("Localization_Language");

            ChangeLanguage((ELanguage)language);
        }
    }
}




