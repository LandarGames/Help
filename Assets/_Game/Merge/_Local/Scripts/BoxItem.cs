using Items;
using Merge;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoxItem : BaseItem, IPointerClickHandler
{
    [SerializeField] private ItemConfig _config;

    private void Start()
    {
        OnChangeIndex?.Invoke(-1);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(gameObject);
        MergeItemSpawner.Instance.Spawn(Slot, Index);
    }

    public override void SetIndex(int index)
    {
        base.SetIndex(index);
    }

    public override ItemConfig GetItemConfig()
    {
        return _config;
    }
}
