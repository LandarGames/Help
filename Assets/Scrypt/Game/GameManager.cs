using UnityEngine;
using TMPro;
using Items;

public class GameManager : MonoBehaviour
{
    public int Lvl = 1;
    public int MaxSlot;

    [SerializeField] private TextMeshProUGUI _textLvl;
    [SerializeField] private Transform[] _points;
    [SerializeField] private GameObject[] _enemys;
    [SerializeField] private MergeItemSpawner _spawner;
    [SerializeField] private MoneyHolder _mh;
    [SerializeField] private int _upEnemy;

    public string _tipeEnemy = "";
    public string _tipeGun = "";

    public bool _up = true;
    private void Start()
    {
         
        if (_tipeEnemy == "")
        {
            NewEnemy();
            _mh.NewEnemy();
        }
        else
        {
            LoadEnemy();
        }
    }

    public void LvlUp()
    {
        if (_up)
        {
            Lvl += 1;
            _up = false;
            MoneyHolder.NewLvls.Invoke();
            _mh.NewEnemy();
            if (Lvl == 10)
            {
                MaxSlot += 5;
            }
            if (Lvl == 20)
            {
                MaxSlot += 5;
            }
            _mh.NewSlot();
        }
    }

    private void LoadEnemy()
    {
        _textLvl.text = $"Уровень {Lvl}";
        for (int i = 0; i < _points.Length; i++)
        {
            int type = int.Parse(_tipeEnemy[i].ToString());
            Instantiate(_enemys[type], _points[i].position, Quaternion.identity);

        }
    }
    private void NewEnemy()
    {
        _textLvl.text = $"Уровень {Lvl}";
        if (Lvl > _enemys.Length)
        {
            foreach (GameObject enemy in _enemys)
            {
                enemy.GetComponent<Enemy>()._healths += _upEnemy;
            }
        }
        foreach (Transform point in _points)
        {
            int tipe = Random.Range(0, Lvl + 1);
            if (tipe < _enemys.Length)
            {
                if (tipe == Lvl + 1)
                {
                    tipe = Random.Range(0, Lvl + 1);
                }
            }
            else
            {
                tipe = Random.Range(0, _enemys.Length - 1);
            }
            Instantiate(_enemys[tipe], point.position, Quaternion.identity);
            _tipeEnemy += tipe;

        }
    }
}
