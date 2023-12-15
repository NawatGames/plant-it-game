using System;
using System.Collections.Generic;
using Interacts;
using UnityEngine;
using UnityEngine.Events;

namespace InventorySystem.NewInventorySystem
{
    public class Category : MonoBehaviour
    {
        Dictionary<String, Slot> _slots = new Dictionary<string, Slot>();
        public UnityEvent<Slot> slotCreatedEvent;
        public UnityEvent<Slot> slotCleanedEvent;
        public string categoryType;
        private SlotCreator _slotCreator;
        public UnityEvent<Category> categoryDeletedEvent;
        [SerializeField] private List<Slot> slotList;

        public void Inject(string categoryName, SlotCreator slotCreator) //método "construtor"
        {
            this._slotCreator = slotCreator;
            this.categoryType = categoryName;
            slotCreatedEvent = new UnityEvent<Slot>();
            slotCleanedEvent = new UnityEvent<Slot>();
        }
        
        public Slot GetSlot(ItemProfileSO itemProfileSo, bool createSlotIfNull = false)
        {
            if (_slots.ContainsKey(itemProfileSo.itemId))
            {
                return _slots[itemProfileSo.itemId];
            }

            if (createSlotIfNull)
            {
                return CreateSlot(itemProfileSo);
            }

            return null;
        }
        
        private Slot CreateSlot(ItemProfileSO itemProfileSo)
        {
            var slot = _slotCreator.CreateSlot(itemProfileSo);
            _slots.Add(itemProfileSo.itemId, slot);
            slot.slotDeletedEvent.AddListener(CleanSlot);
            slotCreatedEvent.Invoke(slot);
            
            return slot;
        }

        private void CleanSlot(Slot slot)
        {
            _slots.Remove(slot.itemId);
            slotCleanedEvent.Invoke(slot);
            Destroy(slot.gameObject);
        }
        
        public void KillSlot(String itemId)
        {
            if (_slots.ContainsKey(itemId))
            {
                var slot = _slots[itemId];
                slot.InvokeSlotDeleted();
                Refresh();
            }
        }

        //private void Update()
        //{
            //Refresh();
        //}

        public void Refresh()
        {
            slotList = new List<Slot>(_slots.Values);
            if (_slots.Count == 0)
            {
                InvokeCategoryDeleted();
            }
        }

        public void InvokeCategoryDeleted()
        {
            categoryDeletedEvent.Invoke(this);
        }

        public void OnDestroy()
        {
            InvokeCategoryDeleted();
        }
    }
}