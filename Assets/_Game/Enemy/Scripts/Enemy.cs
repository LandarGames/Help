using Animation;
using System.Numerics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Health Health { get; private set; }

    public int _healths;
    [SerializeField] private int _profit;

    [SerializeField] private ParticleSystem _damageEffect;
    [SerializeField] private EnemyData _enemyData;
    [SerializeField] private EnemyHalves _halves;
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private GameObject[] _models;

    private void Start()
    {
        Health = new Health(_healths);

        UpdateModel();

        Health.OnDamage += Damage;
        Health.OnDied += Died;
    }

    private void OnDestroy()
    {
        Health.OnDamage -= Damage;
        Health.OnDied -= Died;
    }

    private void Damage(int damage, UnityEngine.Vector3 point)
    {

        if (Health.Healths <= 0)
            return;

        Instantiate(_damageEffect, _spawnPoint.position, UnityEngine.Quaternion.identity);

        transform.Pulse(_enemyData.PulseAnimationConfig);
        UpdateModel();
    }

    private void Died()
    {
        Destroy(gameObject);

        var halves = Instantiate(_halves, transform.position, transform.rotation, null);
        halves.SpawnModel(_models[3].transform);

        var effect = Instantiate(_damageEffect, transform.position, UnityEngine.Quaternion.identity, null);

        effect.transform.localScale = new UnityEngine.Vector3(0.2f, 0.2f, 0.2f);
    }

    private BigInteger CalculationProfit(int damage)
    {
        var a = (float)damage / (float)_healths;
        var b = Mathf.RoundToInt((float)_profit * a);

        return (BigInteger)b;
    }

    void UpdateModel()
    {
        float healthPercentage = (float)Health.Healths / _healths;

        foreach (var model in _models)
            model.SetActive(false);

        if (healthPercentage >= 0.75f)
        {
            _models[0].SetActive(true);
        }
        else if (healthPercentage >= 0.5f)
        {
            _models[1].SetActive(true);
        }
        else if (healthPercentage >= 0.25f)
        {
            _models[2].SetActive(true);
        }
        else
        {
            _models[3].SetActive(true);
        }
    }
}
