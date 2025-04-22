using DG.Tweening;
using Items;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Merge
{
    public abstract class BaseItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Action<int> OnChangeIndex;
        public Action<bool> OnChangeOutline;
        public event Action<bool> OnChangeState;
        public event Action<BaseItem> OnDestroyed;
        public MergeSlot Slot { get; private set; }
        public int Index { get; private protected set; }
        public MergeData MergeData => _mergeData;

        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private MergeData _mergeData;

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnChangeState?.Invoke(true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnChangeState?.Invoke(false);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            transform.SetParent(transform.parent.parent);
            transform.SetAsLastSibling();

            _canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Move();

            _canvasGroup.blocksRaycasts = true;
        }

        public void SetSlot(MergeSlot slot)
        {
            Slot = slot;
            Slot.SetItem(this);

            Move();
        }

        public virtual bool TryUpgradeIndex()
        {
            return false;
        }

        public virtual void SetIndex(int index)
        {
            Index = index;
        }

        public abstract ItemConfig GetItemConfig();

        private void Move()
        {
            Slot.transform.SetAsLastSibling();
            transform.SetParent(Slot.transform);
            _rectTransform.DOAnchorPos(Vector2.zero, _mergeData.MoveDuration);
        }
    }
}
