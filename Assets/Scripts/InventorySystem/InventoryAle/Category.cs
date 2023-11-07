using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace InventorySystem.InventoryAle
{
    public class Category
    {
        Dictionary<String, Slot> _slots = new Dictionary<string, Slot>();
        public UnityEvent<Slot> slotCreatedEvent;
        public UnityEvent<Slot> slotCleanedEvent;
        public Type categoryType;
        private SlotCreator _slotCreator;
        public UnityEvent<Category> categoryDeletedEvent;

        Category(Type categoryType, SlotCreator slotCreator)
        {
            this._slotCreator = slotCreator;
            this.categoryType = categoryType;
            slotCreatedEvent = new UnityEvent<Slot>();
            slotCleanedEvent = new UnityEvent<Slot>();
        }
        
        public Slot GetSlot(string itemId, bool createSlotIfNull = false)
        {
            if (_slots.ContainsKey(itemId))
            {
                return _slots[itemId];
            }

            if (createSlotIfNull)
            {
                return CreateSlot(itemId);
            }

            return null;
        }
        
        private Slot CreateSlot(string itemId)
        {
            var slot = _slotCreator.CreateSlot(itemId);
            _slots.Add(itemId,slot);
            slot.slotDeletedEvent.AddListener(CleanSlot);
            slotCreatedEvent.Invoke(slot);
            return slot;
        }

        private void CleanSlot(Slot slot)
        {
            _slots.Remove(slot.itemId);
            slotCleanedEvent.Invoke(slot);
        }

        public void KillSlot(String itemId)
        {
            if (_slots.ContainsKey(itemId))
            {
                var slot = _slots[itemId];
                slot.InvokeSlotDeleted();
            }
        }
    }
}