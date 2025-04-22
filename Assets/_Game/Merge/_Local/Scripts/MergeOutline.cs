using System.Collections.Generic;
using UnityEngine;
using Items;
using System.Linq;

namespace Merge
{
    public class MergeOutline : MonoBehaviour
    {
        private List<BaseItem> _items = new List<BaseItem>();

        private void Start()
        {
            MergeItemSpawner.Instance.OnSpawn += AddItem;
        }

        private void OnDestroy()
        {
            MergeItemSpawner.Instance.OnSpawn -= AddItem;
        }

        private void AddItem(BaseItem item)
        {
            _items.Add(item);

            item.OnChangeState += (isActive) => 
            {
                SetActiveOutline(isActive, item);
            };
            item.OnDestroyed += RemoveItem;
        }

        private void RemoveItem(BaseItem item)
        {
            item.OnDestroyed -= RemoveItem;

            _items.Remove(item);
        }

        private void SetActiveOutline(bool isActive, BaseItem item)
        {
            var items = _items.Where(i => i.Index == item.Index && i != item).ToArray();

            foreach (var i in items)
            {
                i.OnChangeOutline.Invoke(isActive);
            }
        }
    }
}
