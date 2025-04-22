using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _source;

    private SoundManager _soundManager;

    private void Start()
    {
        _soundManager = SoundManager.Instance;

        _soundManager.OnChangeMute += SetMute;
    }

    private void OnDestroy()
    {
        _soundManager.OnChangeMute -= SetMute;
    }

    public void SetPlay(bool IsPlay)
    {
        if (IsPlay)
            _source.Play();
        else
            _source.Stop();
    }

    private void SetMute(bool isMute)
    {
        _source.mute = isMute;
    }
}
