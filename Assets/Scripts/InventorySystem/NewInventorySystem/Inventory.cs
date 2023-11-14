
using System;
using System.Collections.Generic;
using Interacts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace InventorySystem.NewInventorySystem
{
    public class Inventory : MonoBehaviour
    {
        Dictionary<Type, Category> _categories = new Dictionary<Type, Category>();
        [SerializeField] private CategoryCreator categoryCreator;
        public UnityEvent<Category> categoryCreatedEvent;
        public UnityEvent<Category> categoryCleanedEvent;

        public void SetItem(ItemProfileSO item, int quantity = 1)
        {
            var category = GetCategory(item.GetType(), true);
            var slot = category.GetSlot(item, true);
            slot.SetAmount(quantity);
        }

        public Slot GetSlot(ItemProfileSO item, bool createIfNull = false)
        {
            var category = GetCategory(item.GetType(), createIfNull);
            if (category == null) return null;
            return category.GetSlot(item, createIfNull);
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
            var category = categoryCreator.CreateCategory(categoryType);
            _categories.Add(categoryType, category);
            category.categoryDeletedEvent.AddListener(CleanCategory);
            categoryCreatedEvent.Invoke(category);
            
            return category;
        }

        private void CleanCategory(Category category)
        {
            _categories.Remove(category.categoryType);
            categoryCleanedEvent.Invoke(category);
            Destroy(category.gameObject);
        }
        
        public void KillCategory(Type categoryType)
        {
            if (_categories.ContainsKey(categoryType))
            {
                var category = _categories[categoryType];
                category.InvokeCategoryDeleted();
            }
        }
    }
}