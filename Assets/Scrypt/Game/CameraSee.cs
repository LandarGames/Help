using System.Collections.Generic;
using UnityEngine;

public class CameraSee : MonoBehaviour
{
    public List<GameObject> _targetsGun = new List<GameObject>();


    private float _cor = 0;
     

    private void Update()
    {
        foreach (GameObject target in _targetsGun)
        {
            if (target == null)
            {
                continue;
            }
            if (_cor > target.transform.position.y && target.transform.position.y > -7)
            {
                _cor = target.transform.position.y;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, _cor, 0), 5 * Time.deltaTime);
    }
}
