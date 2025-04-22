using UnityEngine;
using UnityEngine.UI;

public class SoundView : MonoBehaviour
{
    [SerializeField] private Button _buttonMute;

    [SerializeField] private Image _imageButton;

    [SerializeField] private Sprite _spriteUnmute;
    [SerializeField] private Sprite _spriteMute;

    private SoundManager _soundManager;

    private void Start()
    {
        _soundManager = SoundManager.Instance;

        _buttonMute.onClick.AddListener(OnChangeMute);
    }

    private void OnChangeMute()
    {
        _soundManager.ChangeMute();

        _imageButton.sprite = _soundManager.IsMute ? _spriteMute : _spriteUnmute;
    }
}
