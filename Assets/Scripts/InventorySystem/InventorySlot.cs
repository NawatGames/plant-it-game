using System;
using System.Diagnostics.CodeAnalysis;
using KevinCastejon.MoreAttributes;
using UnityEngine;

namespace InventorySystem
{
    public class InventorySlot : MonoBehaviour
    {
        [ReadOnly] public int _amount;
        public ItemProfileSO itemProfile;
        public string itemId;

        public void SetItem(ItemProfileSO item)
        {
            itemProfile = item;
            itemId = item.itemId;
            gameObject.transform.name = itemId;
            _amount = 1;
        }

        public void SetAmount(int newAmount)
        {
            if (_amount >= 0)
            {
                _amount = newAmount;
            }
        }

        public int Amount()
        {
            return _amount;
        }
    }
}