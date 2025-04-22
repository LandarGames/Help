using UnityEngine;
using UnityEngine.UI;

public class ButtonsSound : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;

    [SerializeField] private SoundPlayer _soundPlayer;

    private void Start()
    {
        foreach (var button in _buttons)
            button.onClick.AddListener(() => _soundPlayer.SoundPlay(0));

    }
}
