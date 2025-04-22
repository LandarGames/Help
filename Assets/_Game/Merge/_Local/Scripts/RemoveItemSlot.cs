using Items;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Merge
{
    public class RemoveItemSlot : MonoBehaviour, IDropHandler
    {
        [SerializeField] private GameManager _gm;
        [SerializeField] private MoneyHolder _mh;
        
        public void OnDrop(PointerEventData eventData)
        {
            if (!eventData.pointerDrag.TryGetComponent<BaseItem>(out var item))
                return;
            bool s = false;
            string newItems = ""; 
            for (int i = 0; i < _gm._tipeGun.Length; i++)
            {
                if (item.Index == int.Parse(_gm._tipeGun[i].ToString()) && s == false)
                {
                    s = true;
                }
                else
                {
                   newItems += _gm._tipeGun[i];
                }
            }
            _gm._tipeGun = newItems;
            _mh.SetGun();
            item.Slot.SetItem(null);

            Destroy(item.gameObject);
        }
    }
}

