using Items;
using Merge;
using UnityEngine;

public class MergeItem : BaseItem
{
    [SerializeField] private ItemsData _data;
    private MoneyHolder _moneyHolder;

    private void Awake()
    {
        _moneyHolder = MoneyHolder.Instance;
    }
    public override ItemConfig GetItemConfig()
    {
        return _data.Configs[Index];
    }

    public override bool TryUpgradeIndex()
    {
        if (_data.Configs.Length - 1 <= Index)
            return false;


        _moneyHolder.NewItems(Index);
        _moneyHolder.SetGun();
        Index++;


        OnChangeIndex?.Invoke(Index);

        return true;
    }

    public override void SetIndex(int index)
    {
        base.SetIndex(index);

        OnChangeIndex?.Invoke(Index);
    }
}

