using UnityEngine;

namespace Items
{
    public class ItemDamager : MonoBehaviour
    {

        [SerializeField] private int _hp;

        [SerializeField] private int _damage;
        [SerializeField] private ItemsData _data;
        [SerializeField] private Animator _animator;

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private GameObject _ps;

        [SerializeField] private TextHit _textDamage;
        [SerializeField] private TextHit _textMoney;

        [SerializeField] private Transform _canvas;




        private void OnTriggerEnter(Collider other)
        {
            GetComponent<AudioSource>().Play();
            if (!other.TryGetComponent<Enemy>(out var enemy))
                return;

            enemy.Health.TakeDamage(_damage);
            _hp -= 1;

            MoneyHolder.Instance.ChangeMoney(_damage);

            _textDamage._text.text = _damage.ToString();
            _textMoney._text.text = _damage.ToString();
            GameObject td = Instantiate(_textDamage.gameObject, _canvas.position,_canvas.rotation,_canvas);
            GameObject tm = Instantiate(_textMoney.gameObject, _canvas.position + new Vector3(0,1,0),_canvas.rotation,_canvas);
            GameObject effect = Instantiate(_ps, transform.position, transform.rotation);
            Destroy(effect, 1);
            Destroy(td, 1);
            Destroy(tm , 1);

            if (enemy.Health.Healths <= 0)
                return;
            if (_hp <= 0)
            {
                ItemSpawner.DeadKnife.Invoke();
                Destroy(gameObject);
            }

            _rigidbody.velocity = Vector3.zero;

            _rigidbody.AddForce(Vector3.up * _data.JumpForce, ForceMode.Force);
            _animator.SetTrigger("Damage");
        }
    }
}
