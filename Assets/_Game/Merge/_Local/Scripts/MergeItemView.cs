using Animation;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Merge
{
    public class MergeItemView : MonoBehaviour
    {
        [SerializeField] private Image _imageIcon;
        [SerializeField] private TMP_Text _textIndex;
        [SerializeField] private Outline _outline;

        [SerializeField] private BaseItem _item;

        private void Awake()
        {
            _item.OnChangeIndex += DisplayInfo;
            _item.OnChangeState += DisplayState;
            _item.OnChangeOutline += DisplayOutline;
        }

        private void OnDestroy()
        {
            _item.OnChangeIndex -= DisplayInfo;
            _item.OnChangeState -= DisplayState;
            _item.OnChangeOutline -= DisplayOutline;
        }

        private void DisplayInfo(int index)
        {
            _imageIcon.sprite = _item.GetItemConfig().Icon;

            if (index == -1)
                _textIndex.gameObject.SetActive(false);

            _textIndex.text = (index + 1).ToString();

            _imageIcon.transform.Pulse(_item.MergeData.PulseAnimationConfig);
        }

        private void DisplayState(bool isDrag)
        {
            _textIndex.DOFade(isDrag ? 0 : 1, _item.MergeData.FadeDuration);
            _imageIcon.transform.DOScale(isDrag ? _item.MergeData.AnimationScale : 1, _item.MergeData.ScaleDuration);
        }

        private void DisplayOutline(bool isActive)
        {
            _outline.enabled = isActive;
        }
    }
}