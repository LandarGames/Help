using System;

public class SoundManager : Singleton<SoundManager>
{
    public event Action<bool> OnChangeMute;

    public bool IsMute { get; private set; }

    private void Start()
    {
        OnChangeMute?.Invoke(IsMute);
    }

    public void ChangeMute()
    {
        IsMute = !IsMute;

        OnChangeMute?.Invoke(IsMute);
    }
}
