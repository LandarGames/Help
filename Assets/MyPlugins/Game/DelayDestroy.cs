using System.Collections;
using UnityEngine;

public class DelayDestroy : MonoBehaviour
{
    [SerializeField] private float _delayTime;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_delayTime);

        Destroy(gameObject);
    }
}
