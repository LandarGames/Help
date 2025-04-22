using System;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    public event Action<Collision> OnCollisionEntered;
    public event Action<Collision> OnCollisionStayed;
    public event Action<Collision> OnCollisionExited;

    public event Action<Collider> OnTriggerEntered;
    public event Action<Collider> OnTriggerStayed;
    public event Action<Collider> OnTriggerExited;

    private void OnCollisionEnter(Collision collision) => OnCollisionEntered?.Invoke(collision);

    private void OnCollisionStay(Collision collision) => OnCollisionStayed?.Invoke(collision);

    private void OnCollisionExit(Collision collision) => OnCollisionExited?.Invoke(collision);


    private void OnTriggerEnter(Collider other) => OnTriggerEntered?.Invoke(other);

    private void OnTriggerStay(Collider other) => OnTriggerStayed?.Invoke(other);

    private void OnTriggerExit(Collider other) => OnTriggerExited?.Invoke(other);

}
