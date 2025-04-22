using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

namespace Items
{
    public class ItemsBuy : MonoBehaviour
    {
        public event Action<int, BigInteger, int> OnChangeItem;
        public event Action<int> OnChangeCountBuy;

        [SerializeField] private ItemsBuyData _data;
        [SerializeField] private MergeItemSpawner _spawner;
        [SerializeField] private GameManager _gm;

        [SerializeField] private MoneyHolder _moneyHolder;

        public int _currentItemId;
        public int _currentCountBuy;
        

        private void Start()
        {
            _moneyHolder = MoneyHolder.Instance;

            OnChangeItem?.Invoke(_currentItemId, _data.Configs[_currentItemId].Price, _data.Configs[_currentItemId].CountBuy);
            OnChangeCountBuy?.Invoke(_currentCountBuy);
            for (int i = 0; i < _gm._tipeGun.Length; i++)
            {
                int tipe = int.Parse(_gm._tipeGun[i].ToString());
                _spawner.Spawn(index: _data.Configs[tipe].itemId);
            }
        }

        public bool TryBuy()
        {
            var price = _data.Configs[_currentItemId].Price;

            if (_moneyHolder.Money < price)
                return false;

            
            _gm._tipeGun += $"{_currentItemId}";
            _moneyHolder.SetGun();
            _moneyHolder.ChangeMoney(-price);

            _spawner.Spawn(index: _data.Configs[_currentItemId].itemId);
            _currentCountBuy++;

            OnChangeCountBuy?.Invoke(_currentCountBuy);

            if (_currentCountBuy >= _data.Configs[_currentItemId].CountBuy)
                ChangeItem();

            return true;
        }

        private void ChangeItem()
        {
            if(_data.Configs.Length > _currentItemId + 1)
                _currentItemId++;

            _currentCountBuy = 0;

            OnChangeCountBuy?.Invoke(_currentCountBuy);
            OnChangeItem?.Invoke(_currentItemId, _data.Configs[_currentItemId].Price, _data.Configs[_currentItemId].CountBuy);
        }
    }
}