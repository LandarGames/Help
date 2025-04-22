using UnityEngine;
using UnityEngine.UI;

namespace Localization
{
    public class LocalizationView : MonoBehaviour
    {
        [SerializeField] private Button[] _buttons;

        private Localization _localization;

        private void Start()
        {
            _localization = Localization.Instance;

            for (int i = 0; i < _buttons.Length; i++)
            {
                int index = i;
                _buttons[index].onClick.AddListener(() => _localization.ChangeLanguage(index));
            }
        }
    }
}
