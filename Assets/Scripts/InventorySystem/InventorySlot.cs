using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using Interacts;
using KevinCastejon.MoreAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace InventorySystem
{
    public class InventorySlot : MonoBehaviour
    {
        [ReadOnly] public int _amount;
        public ItemProfileSO itemProfile;
        public string itemId;
        public UnityEvent<InventorySlot> slotDeletedEvent;
        public UnityEvent<InventorySlot> slotUpdatedEvent;

        public void SetItem(ItemProfileSO item,int amount = 1)
        {
            itemProfile = item;
            itemId = item.itemId;
            gameObject.transform.name = itemId;
            _amount = amount;
        }

        public void SetAmount(int newAmount)
        {
            if (_amount >= 0)
            {
                _amount = newAmount;
            }
            slotUpdatedEvent.Invoke(this);
        }

        public int Amount()
        {
            return _amount;
        }

        public void Consume()
        {
            if(!itemProfile.consumable) return;
            _amount--;
            if (_amount <= 0)
            {
                slotDeletedEvent.Invoke(this);
                Destroy(gameObject);
                return;
            }
            slotUpdatedEvent.Invoke(this);
        }
    }
}