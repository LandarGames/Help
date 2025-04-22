using DG.Tweening;
using UnityEngine;

namespace Animation
{
    public static class SimpleAnimations
    {
        public static void Pulse(this Transform transform, PulseAnimationConfig config)
        {
            Sequence scaleSequence = DOTween.Sequence();

            scaleSequence.Append(transform.DOScale(config.PulseScale, config.Duraction));
            scaleSequence.Append(transform.DOScale(config.EndScale, config.Duraction));

            scaleSequence.Play();
        }
    }
}

