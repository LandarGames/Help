using Animation;
using System.Numerics;
using TMPro;
using UI;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMoney;
    [SerializeField] private string _suffix;

    [SerializeField] private PulseAnimationConfig _pulseAnimationConfig;

    [SerializeField] private MoneyHolder _holder;

    private void Awake()
    {
        _holder.OnChangeMoney += DisplayMoney;
    }

    private void OnDestroy()
    {
        _holder.OnChangeMoney -= DisplayMoney;
    }

    private void DisplayMoney(BigInteger profit)
    {
        _textMoney.text = _suffix + UITools.ReducingNumber(_holder.Money);

        if(profit != 0)
            _textMoney.transform.Pulse(_pulseAnimationConfig);
    }
}
