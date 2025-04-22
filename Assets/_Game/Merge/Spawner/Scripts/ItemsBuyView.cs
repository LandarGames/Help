using Localization;
using System.Numerics;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    public class ItemsBuyView : MonoBehaviour
    {
        [SerializeField] private LocalizationText _textPrice;
        [SerializeField] private Image _imageIcon;
        [SerializeField] private TMP_Text _textCountBuy;

        [SerializeField] private Button _buttonBuy;

        [SerializeField] private ItemsBuy _itemBuy;
        [SerializeField] private ItemsData _itemsData;
        [SerializeField] private MoneyHolder _mh;

        public int _maxCountBuy;

        private void Awake()
        {
            _buttonBuy.onClick.AddListener(ClickBuy);

            _itemBuy.OnChangeCountBuy += DisplayCountBuy;
            _itemBuy.OnChangeItem += DisplayItem;
        }

        private void OnDestroy()
        {
            _itemBuy.OnChangeCountBuy -= DisplayCountBuy;
            _itemBuy.OnChangeItem -= DisplayItem;
        }

        private void DisplayCountBuy(int count)
        {
            _textCountBuy.text = $"{count}/{_maxCountBuy}";
            _mh.BuyItem();
            
        }

        private void DisplayItem(int itemId, BigInteger price, int maxCountBuy)
        {
            _maxCountBuy = maxCountBuy;

            _imageIcon.sprite = _itemsData.Configs[itemId].Icon;
            _textPrice.UpdateText(UITools.ReducingNumber(price), 1);
        }

        private void ClickBuy()
        {
            if (!_itemBuy.TryBuy())
                Debug.Log("Уведомления");
        }
    }
}