using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Window : MonoBehaviour
    {
        #region Events

        public event Action OnStartOpen;
        public event Action OnEndOpen;
        public event Action OnStartClose;
        public event Action OnEndClose;

        #endregion

        [SerializeField] private Transform _panel;

        [SerializeField] private Button _buttonOpen;
        [SerializeField] private Button _buttonClose;

        [SerializeField] private CanvasGroup _canvasGroup;

        [SerializeField] private float _fadeDuration;
        [SerializeField] private float _pulseDuration;

        private void Awake()
        {
            SetActive(false, 0);

            _buttonOpen?.onClick.AddListener(Open);
            _buttonClose?.onClick.AddListener(Close);
        }

        public void Open()
        {
            SetActive(true, 0);

            _canvasGroup.DOFade(1, _fadeDuration).OnComplete(() => 
            {
                PulseAnimation(_panel, 1, OnEndOpen);
            });

            OnStartOpen?.Invoke();
        }

        public void Close()
        {
            SetActive(false, 1);

            _canvasGroup.DOFade(0, _fadeDuration)
                .OnComplete(() => {
                    _panel.localScale = new Vector2(0.00001f, 0.00001f);

                    OnEndClose?.Invoke();
                });

            OnStartClose?.Invoke();
        }

        public void SetActive(bool isActive, float alpha)
        {
            _canvasGroup.interactable = isActive;
            _canvasGroup.blocksRaycasts = isActive;

            _canvasGroup.alpha = alpha;

            _panel.localScale = isActive ? new Vector2(0.00001f, 0.00001f) : Vector2.one;
        }

        private void PulseAnimation(Transform transform, float scaleEnd, Action callback = null)
        {
            transform.DOScale(1.15f, _pulseDuration / 2)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                transform.DOScale(scaleEnd, _pulseDuration / 2)
                    .SetEase(Ease.InQuad).OnComplete(() =>
                    {
                        callback?.Invoke();
                    });
            });
        }
    }
}

