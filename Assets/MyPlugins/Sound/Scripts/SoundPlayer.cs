using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private Sound _prefabSound;
    [SerializeField] private AudioClip[] _clips;

    private SoundManager _soundManager;

    private void Awake()
    {
        _soundManager = SoundManager.Instance;
    }

    public void SoundPlay(int id)
    {
        var source = Instantiate(_prefabSound, null);

        source?.Play(_clips[id], _soundManager.IsMute);
    }
}
