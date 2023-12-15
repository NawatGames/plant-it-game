
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
        Dictionary<String, Category> _categories = new Dictionary<String, Category>();
        [SerializeField] private CategoryCreator categoryCreator;
        public UnityEvent<Category> categoryCreatedEvent;
        public UnityEvent<Category> categoryCleanedEvent;

        public void SetItem(ItemProfileSO item, int quantity = 1)
        {

            string categoryName = AttributeExtensions.GetAttributeValue<ItemCategory,string>(item.GetType(), (x => x.CategoryName));
            Debug.Log(categoryName);
            var category = GetCategory(categoryName, true);
            var slot = category.GetSlot(item, true);
            slot.SetAmount(quantity);
        }

        public Slot GetSlot(ItemProfileSO item, bool createIfNull = false)
        {
            string categoryName = AttributeExtensions.GetAttributeValue<ItemCategory,string>(item.GetType(), (x => x.CategoryName));
            Debug.Log(categoryName);
            var category = GetCategory(categoryName, createIfNull);
            if (category == null) return null;
            return category.GetSlot(item, createIfNull);
        }

        public Category GetCategory(string categoryName, bool createCategoryIfNull = false)
        {
            if (_categories.ContainsKey(categoryName))
            {
                return _categories[categoryName];
            }

            if (createCategoryIfNull)
            {
                return CreateCategory(categoryName);
            }

            return null;
        }

        private Category CreateCategory(string categoryName)
        {
            var category = categoryCreator.CreateCategory(categoryName);
            _categories.Add(categoryName, category);
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
        
        public void KillCategory(string categoryName)
        {
            if (_categories.ContainsKey(categoryName))
            {
                var category = _categories[categoryName];
                category.InvokeCategoryDeleted();
            }
        }
    }
}