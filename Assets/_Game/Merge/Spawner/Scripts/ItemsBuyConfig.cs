using System.Numerics;
using UnityEngine;

namespace Items
{
    [System.Serializable]
    public struct ItemsBuyConfig
    {
        public int itemId;
        public BigInteger Price => BigInteger.Parse(_price);
        public int CountBuy;

        [SerializeField] private string _price;
    }
}

