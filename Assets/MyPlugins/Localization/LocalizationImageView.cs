using UnityEngine;
using UnityEngine.UI;

namespace Localization
{
    public class LocalizationImageView : MonoBehaviour
    {
        [SerializeField] private Sprite[] _sprites = new Sprite[4];
        [SerializeField] private Image _image;

        private Localization _localization;

        private void Awake()
        {
            _localization = Localization.Instance;

            _localization.OnChangeLanguage += ChangeLanguage;
        }

        private void Start()
        {
            _image.sprite = _sprites[(int)_localization.Language];
            _image.SetNativeSize();
        }

        private void OnDestroy()
        {
            _localization.OnChangeLanguage -= ChangeLanguage;
        }

        private void ChangeLanguage(ELanguage language)
        {
            _image.sprite = _sprites[(int)language];
            _image.SetNativeSize();
        }
    }
}
