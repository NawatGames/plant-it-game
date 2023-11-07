
using System;
using System.Collections.Generic;
using KevinCastejon.MoreAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

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

    public class SlotCreator : MonoBehaviour
    {
        public GameObject prefab;
        public Slot CreateSlot(string itemId)
        {
            var clone = Instantiate(prefab);
            Slot newSlot = clone.GetComponent<Slot>();
            return newSlot;
        }
    }
    
    public class Slot
    {
        [ReadOnly] private int _amount;
        public ItemProfileSO itemProfile;
        public string itemId;
        public UnityEvent<Slot> slotDeletedEvent;
        public UnityEvent<Slot> slotUpdatedEvent;

        public int GetAmount()
        {
            return _amount;
        }
        
        Slot(ItemProfileSO item, int amount = 1)
        {
            itemProfile = item;
            itemId = item.itemId;
            _amount = amount;
        }

        public void AddAmount(int quantity)
        {
            if (_amount >= 0)
            {
                _amount += quantity;
            }
            if (_amount <= 0)
            {
                InvokeSlotDeleted();
            }
            slotUpdatedEvent.Invoke(this);
        }

        public void SetAmount(int quantity)
        {
            if (_amount >= 0)
            {
                _amount = quantity;
            }
            if (_amount <= 0)
            {
                InvokeSlotDeleted();
            }
            slotUpdatedEvent.Invoke(this);
        }
        
        //Player usa item, item abaixo de 0, logo deve ser removido do inventário,
        //item removido deve ter categoria e tira-lo da categoria e disparar um evento a nivel de categoria/slot
        //para limpar as variaveis do slot, depois disso formamos a categoria, 
        //a categoria se atualiza, com isso o iventario deve se atualizar tambem,
        public void RemoveAmount(int quantity)
        {
            _amount-= quantity;
            if (_amount <= 0)
            {
                InvokeSlotDeleted();
            }
            slotUpdatedEvent.Invoke(this);
        }

        public void Consume(int quantity = 1)
        {
            if(!itemProfile.consumable) return;
            RemoveAmount(quantity);
        }

        public void InvokeSlotDeleted()
        {
            slotDeletedEvent.Invoke(this);
        }
    }
    
    public class InventoryAle
    {
        Dictionary<Type, Category> _categories = new Dictionary<Type, Category>();
        private CategoryCreator _categoryCreator;
        public UnityEvent<Category> categoryCreatedEvent;
        public UnityEvent<Category> categoryCleanedEvent;

        public void SetItem(ItemProfileSO item, int quantity = 1)
        {
            var category = GetCategory(item.GetType(), true);
            var slot = category.GetSlot(item.itemId, true);
            slot.SetAmount(quantity);
        }

        public Slot GetSlot(ItemProfileSO item, bool createIfNull = false)
        {
            var category = GetCategory(item.GetType(), createIfNull);
            if (category == null) return null;
            return category.GetSlot(item.itemId, createIfNull);
        }

            public Category GetCategory(Type categoryType, bool createCategoryIfNull = false)
        {
            if (_categories.ContainsKey(categoryType))
            {
                return _categories[categoryType];
            }

            if (createCategoryIfNull)
            {
                return CreateCategory(categoryType);
            }

            return null;
        }

        private Category CreateCategory(Type categoryType)
        {
            var category = _categoryCreator.CreateCategory(categoryType);
            _categories.Add(categoryType, category);
            category.categoryDeletedEvent.AddListener(CleanCategory);
            categoryCreatedEvent.Invoke(category);
            return category;
        }

        private void CleanCategory(Category category)
        {
            _categories.Remove(category.categoryType);
            categoryCleanedEvent.Invoke(category);
        }
    }

    public class CategoryCreator : MonoBehaviour
    {
        public GameObject prefab;
        public Category CreateCategory(Type categoryType)
        {
            var clone = Instantiate(prefab);
            Category newCategory = clone.GetComponent<Category>();
            return newCategory;
        }
    }
}