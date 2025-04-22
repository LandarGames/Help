using System.Collections;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _delayDestroy;

    public void Play(AudioClip clip, bool isMute)
    {
        _audioSource.mute = isMute;
        _audioSource.clip = clip;

        _audioSource.Play();

        StartCoroutine(DestroyAudio());
    }

    private IEnumerator DestroyAudio()
    {
        yield return new WaitForSeconds(_delayDestroy);

        Destroy(gameObject);
    }
}
