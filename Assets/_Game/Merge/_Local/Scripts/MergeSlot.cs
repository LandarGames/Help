using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace Merge
{
    public class MergeSlot : MonoBehaviour, IDropHandler
    {
        public BaseItem Item { get; private set; }
        public RectTransform RectTransform => _rectTransform;

        [SerializeField] private RectTransform _rectTransform;

        public void OnDrop(PointerEventData eventData)
        {
            if (!eventData.pointerDrag.TryGetComponent<BaseItem>(out var item) || item == Item)
                return;

            if (Item == null)
            {
                item.Slot.SetItem(null);
                item.SetSlot(this);
            }
            else if (Item.Index == item.Index && Item.TryUpgradeIndex())
            {
                item.Slot.SetItem(null);
                Destroy(item.gameObject);
            }
            else if (Item.Index != item.Index)
            {
                Item.SetSlot(item.Slot);
                item.SetSlot(this);
            }
            else
            {
                Item.SetSlot(Item.Slot);
            }
        }

        public void SetItem(BaseItem item)
        {
            Item = item;
        }
    }
}
