using Animation;
using UnityEngine;

namespace Merge
{
    [CreateAssetMenu(menuName = "Datas/Merge Data")]
    public class MergeData : ScriptableObject
    {
        public float MoveDuration => _moveDuration;
        public float ScaleDuration => _scaleDuration;
        public float FadeDuration => _fadeDuration;
        public PulseAnimationConfig PulseAnimationConfig => _pulseAnimationConfig;
        public float AnimationScale => _animationScale;

        [SerializeField] private float _moveDuration;
        [SerializeField] private float _scaleDuration;
        [SerializeField] private float _fadeDuration;
        [SerializeField] private PulseAnimationConfig _pulseAnimationConfig;
        [SerializeField] private float _animationScale;
    }
}