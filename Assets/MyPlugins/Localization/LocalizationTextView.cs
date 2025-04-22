using TMPro;
using UnityEngine;

namespace Localization
{
    public class LocalizationTextView : MonoBehaviour
    {
        [SerializeField] LocalizationText _text;

        private Localization _localization;

        private void Awake()
        {
            _localization = Localization.Instance;

            _localization.OnChangeLanguage += ChangeLanguage;
        }

        private void Start()
        {
            _text.UpdateText();
        }

        private void OnDestroy()
        {
            _localization.OnChangeLanguage -= ChangeLanguage;
        }

        private void ChangeLanguage(ELanguage language)
        {
            _text.UpdateText();
        }
    }
}
