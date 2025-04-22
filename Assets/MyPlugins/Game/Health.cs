using System;
using UnityEngine;

public class Health
{
    public event Action OnDied;
    public event Action<int> OnChangeHealth;
    public event Action<int, Vector3> OnDamage;

    public int Healths { get; private set; }

    public Health(int healths = 0)
    {
        Healths = healths;
    }

    public void SetHealth(int healths)
    {
        Healths = healths;

        OnChangeHealth?.Invoke(Healths);
    }

    public void TakeDamage(int damage, Vector3 point = new Vector3())
    {
        if(damage < 0)
            Debug.LogException(new Exception("Negative damage"));

        Healths -= damage;

        if (Healths <= 0)
            Died();

        OnDamage?.Invoke(damage, point);
        OnChangeHealth?.Invoke(Healths);
    }

    private void Died()
    {
        Healths = 0;
        OnDied?.Invoke();
    }
}
