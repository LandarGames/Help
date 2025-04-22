using Items;
using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class MoneyHolder : Singleton<MoneyHolder>
{
    public event Action<BigInteger> OnChangeMoney;

    public BigInteger Money { get; private set; }

    public List<BigInteger> _enemys = new List<BigInteger>();
    public BigInteger Lvl { get; private set; }

    [SerializeField] private GameManager _gm;
    [SerializeField] private SoundPlayer _soundPlayer;
    [SerializeField] private ItemsBuyView _ibv;
    [SerializeField] private ItemsBuy _ib;

    public static Action NewLvls;
    public static Action UpItem;

    private void Awake()
    {
        Load();
        NewLvls += NewLvl;
    }

    public void ChangeMoney(BigInteger profit)
    {
        //if (profit > 0);
           //_soundPlayer.SoundPlay(0);

        Money += profit;
        SaveService.SetString("Money", Money.ToString());

        OnChangeMoney?.Invoke(profit);
    }

    public void BuyItem()
    {
        SaveService.SetInt("Buy", _ib._currentCountBuy);
        SaveService.SetInt("Index", _ib._currentItemId);
    }

    public void NewEnemy()
    {
        SaveService.SetString("enemys", _gm._tipeEnemy);
    }

    public void NewSlot()
    {
        SaveService.SetInt("Slot",_gm.MaxSlot);
    }

    public void NewItems(int endIndex)
    {
        string newItem = "";
        bool gets = false;
        bool ustr = false;
        for (int i = 0; i < _gm._tipeGun.Length; i++)
        {
            Debug.Log(int.Parse(_gm._tipeGun[i].ToString()) == endIndex);
            if (int.Parse(_gm._tipeGun[i].ToString()) == endIndex && gets == false && ustr == false)
            {
                ustr = true;
                continue;
            }
            if (int.Parse(_gm._tipeGun[i].ToString()) == endIndex && gets == false && ustr == true)
            {
                newItem += $"{endIndex + 1}";
                gets = true;
                continue;
            }
            else
            {
                newItem += _gm._tipeGun[i];
            }
        }

        _gm._tipeGun = newItem;
    }

    public void NewLvl()
    {
        SaveService.SetInt("Lvl",_gm.Lvl);
        _gm._tipeEnemy = "";
    }

    public void SetGun()
    {
        SaveService.SetString("guns", _gm._tipeGun);
    }

    public void Load()
    {
        var buy = SaveService.GetInt("Buy");
        var number = SaveService.GetString("Money");
        var lvl = SaveService.GetInt("Lvl");
        var enemy = SaveService.GetString("enemys");
        var gun = SaveService.GetString("guns");
        var item = SaveService.GetInt("Index");
        var slot = SaveService.GetInt("Slot");

        if (string.IsNullOrWhiteSpace(number))
            number = "0";

        _ib._currentItemId = item;
        _ib._currentCountBuy = buy;
        _gm.Lvl = lvl;
        _gm._tipeEnemy = enemy;
        _gm._tipeGun = gun;
        _gm.MaxSlot = slot;
        Money = BigInteger.Parse(number);

        OnChangeMoney?.Invoke(Money);
    }
}
