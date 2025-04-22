using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "Datas/Items Buy Data")]
    public class ItemsBuyData : ScriptableObject
    {
        public ItemsBuyConfig[] Configs => _configs;

        [SerializeField] private ItemsBuyConfig[] _configs;
    }
}
