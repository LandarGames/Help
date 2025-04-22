using UnityEngine;

public class EnemyHalves : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;

    public void SpawnModel(Transform model)
    {
        var childA = model.GetChild(0);
        var childB = model.GetChild(1);

        var halvesA = Instantiate(childA, _pointA);
        halvesA.transform.localPosition = model.localPosition;
        halvesA.transform.localRotation = model.localRotation;
        halvesA.transform.localScale = model.localScale;

        var halvesB = Instantiate(childB, _pointB);
        halvesB.transform.localPosition = model.localPosition;
        halvesB.transform.localRotation = model.localRotation;
        halvesB.transform.localScale = model.localScale;
    }
}
