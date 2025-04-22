using Merge;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Items
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private MergeSlot[] _slots;
        [SerializeField] private ItemsData _data;
        [SerializeField] private Transform _content;
        [SerializeField] private CameraSee _cm;

        private int _knife = 0;
        private bool _cooldown;
        [SerializeField] private GameObject _ui;
        [SerializeField] private GameManager _gm;

        public static Action DeadKnife;

        private void Awake()
        {
            DeadKnife += BreakKnife;
        }
        public void BreakKnife()
        {
            _knife -= 1;
            if (_knife <= 0)
            {
                if (_gm._up == false)
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
        public void Spawn()
        {
            if (_gm._tipeGun == "")
            {
                return;
            }
            _ui.SetActive(false);
            foreach (var slot in _slots)
            {
                var item = slot.Item;

                if (item == null || !item.TryGetComponent<MergeItem>(out var i))
                    continue;

                var newItem = Instantiate(_data.Configs[item.Index].Prefab, slot.transform.position, Quaternion.identity, _content);
                _gm._tipeGun += item.Index;

                _cm._targetsGun.Add(newItem.gameObject);
                newItem.transform.localPosition = new Vector3(newItem.transform.localPosition.x, newItem.transform.position.y, 0);
                _knife++;
            }
            Debug.Log(_knife);
        }
    }
}

