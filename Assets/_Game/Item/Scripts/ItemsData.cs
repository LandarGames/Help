using System.Collections;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "Datas/Items Data")]
    public class ItemsData : ScriptableObject
    {
        public ItemConfig[] Configs => _configs;
        public float JumpForce => _jumpForce;

        [SerializeField] private ItemConfig[] _configs;
        [SerializeField] private float _jumpForce;
    }
}