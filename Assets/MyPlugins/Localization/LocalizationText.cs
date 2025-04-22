using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Localization
{
    [System.Serializable]
    public class LocalizationText
    {
        [SerializeField] private TMP_Text _text;

        [TextArea]
        [SerializeField]
        private string[] _texts = new string[]
        {
            "English",
            "Russian",
            "Portuguese",
            "German"
        };

        public void UpdateText()
        {
            _text.text = _texts[(int)Localization.Instance.Language];
        }

        public void UpdateText(string suffix, int position = 0)
        {
            _text.text = InsertString(_texts[(int)Localization.Instance.Language], suffix, position);
        }

        private string InsertString(string originalString, string insertString, int position)
        {
            string[] words = originalString.Split(' ');
            List<string> wordsList = new List<string>(words);
            wordsList.Insert(position, insertString);
            return string.Join(" ", wordsList.ToArray());
        }
    }
}
