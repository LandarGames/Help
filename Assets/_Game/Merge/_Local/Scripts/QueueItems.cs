using Items;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Merge
{
    public class QueueItems : MonoBehaviour
    {
        public event Action OnChangeItems;

        public List<BaseItem> Items { get; private set; }

        private void Awake()
        {
            Items = new List<BaseItem>();
        }

        public void AddItem(BaseItem item)
        {
            Items.Add(item);

            OnChangeItems?.Invoke();
        }

        public void RemoveItem()
        {
            if (!MergeItemSpawner.Instance.TryRandomSlot(out var slot))
                return;

            var item = Items[Items.Count - 1];

            MergeItemSpawner.Instance.Spawn(prefabItem: item, index: item.Index);
            Items.Remove(item);

            OnChangeItems?.Invoke();
        }
    }
}
