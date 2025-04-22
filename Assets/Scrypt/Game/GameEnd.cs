using Items;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private GameManager _gm;
    [SerializeField] private int _money;
    [SerializeField] private GameObject _canvas;

    [SerializeField] private TextHit _text;
    [SerializeField] private Sprite _sprteOpen;
    [SerializeField] private GameObject _ps;
    [SerializeField] private ItemSpawner _is;
    private bool _open;

    private void Awake()
    {
        _open = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        _is.BreakKnife();
        if (_open)
        {
            return;
        }
        if (other.GetComponent<ItemDamager>() && _open == false)
        {
            _ps.SetActive(true);
            _text._text.text = "50";
            for (int i = 0; i < _gm.Lvl; i++)
            {
                GameObject effect = Instantiate(_text.gameObject, _canvas.transform.position + new Vector3(Random.Range(0.5f,-0.5f),Random.Range(0.5f,-0.5f),0), _canvas.transform.rotation,_canvas.transform);
                Destroy(effect,1);
            }
            MoneyHolder.Instance.ChangeMoney(_money * _gm.Lvl);
            _gm.LvlUp();
            _open = true;
            GetComponent<SpriteRenderer>().sprite = _sprteOpen;
        }
    }
}
