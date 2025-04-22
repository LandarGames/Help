using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Merge
{
    public class QueueItemsView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _groupQueue;
        [SerializeField] private Image _imageIcon;
        [SerializeField] private QueueItems _queueItems;
        [SerializeField] private TextMeshProUGUI _textHow;

        private void Start()
        {
            _queueItems.OnChangeItems += DisplayQueue;
            if (_queueItems.Items.Count <= 0)
            {
                _groupQueue.SetActive(false);
            }
            else
            {
                _textHow.text = _queueItems.Items.Count.ToString();
                _groupQueue.SetActive(true);
                _imageIcon.sprite = _queueItems.Items[_queueItems.Items.Count - 1].GetItemConfig().Icon;
            }

        }

        private void OnDestroy()
        {
            _queueItems.OnChangeItems -= DisplayQueue;
        }

        private void DisplayQueue()
        { 
            if(_queueItems.Items.Count <= 0)
            {
                _groupQueue.SetActive(false);
                return;
            }

            _textHow.text = _queueItems.Items.Count.ToString();

            _groupQueue.SetActive(true);
            _imageIcon.sprite = _queueItems.Items[_queueItems.Items.Count - 1].GetItemConfig().Icon;
        }
    }
}