using Merge;
using System;
using System.Linq;
using UnityEngine;

namespace Items
{
    public class MergeItemSpawner : Singleton<MergeItemSpawner>
    {
        public event Action<BaseItem> OnSpawn;

        [SerializeField] private MergeItem _prefabItem;
        [SerializeField] private MergeSlot[] _slots;

        [SerializeField] private ItemsData _data;

        [SerializeField] private QueueItems _queueItems;
        [SerializeField] private GameManager _gm;

        public void NewSlot()
        {
            for (int i = 0; i < _gm.MaxSlot; i++)
            {
                _slots[i].gameObject.SetActive(true);
            }
        }
        public void Spawn(MergeSlot slot = null, int index = 0, BaseItem prefabItem = null)
        {
            if (prefabItem == null)
                prefabItem = _prefabItem;

            if (slot == null)
                if (TryRandomSlot(out var randomSlot))
                    slot = randomSlot;
                else
                {
                    prefabItem.SetIndex(index);
                    _queueItems.AddItem(prefabItem);
                    return;
                }

            var item = Instantiate(prefabItem, slot.transform);

            item.transform.SetParent(slot.transform);

            item.SetSlot(slot);
            slot.SetItem(item);

            item.SetIndex(index);

            OnSpawn?.Invoke(item);
        }

        public bool TryRandomSlot(out MergeSlot randomSlot)
        {
            randomSlot = null;

            var freeSlots = _slots.Where(slot => slot.Item == null).ToArray();

            if (freeSlots.Length == 0)
                return false;

            randomSlot = freeSlots[UnityEngine.Random.Range(0, freeSlots.Length )];

            return true;
        }
    }
}
