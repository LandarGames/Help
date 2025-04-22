using Animation;
using UnityEngine;

[CreateAssetMenu(menuName = "Datas/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public PulseAnimationConfig PulseAnimationConfig => _pulseAnimationConfig;

    [SerializeField] private PulseAnimationConfig _pulseAnimationConfig;
}
