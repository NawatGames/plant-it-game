using System;
using System.Collections.Generic;
using System.Linq;
using InventorySystem;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace InventorySystem
{
    public class InventoryManagerNew : MonoBehaviour
    {
        private Dictionary<System.Type,Dictionary<string,GameObject>> _inventory = 
        new Dictionary<System.Type, Dictionary<string, GameObject>>();

        private Dictionary<System.Type, GameObject> _categoryGameObjects = new Dictionary<Type, GameObject>();

        public UnityEvent<System.Type> categoryCreatedEvent;
        public UnityEvent<InventorySlot> slotCreatedEvent;
        public UnityEvent<InventorySlot> slotDeletedEvent;

        public ItemProfileSO[] test;
        private void Awake()
        {
            foreach (ItemProfileSO item in test)
            {
                CreateSlot(item);
                //_inventory.Add(item.GetType(),new Dictionary<string, GameObject>());
            }
        }
        
        public Dictionary<string,GameObject> GetCategory(ItemProfileSO item)
        {
            System.Type category = item.GetType();
            return GetCategory(category);
        }
        
        public Dictionary<string,GameObject> GetCategory(System.Type category)
        {
            if (_inventory.Keys.Contains(category))
            {
                return _inventory[category];
            }
            return null;
        }
        
        public (InventorySlot,GameObject) GetItemSlot(ItemProfileSO item)
        {
            Dictionary<string,GameObject> category = GetCategory(item);
            if (category != null)
            {
                if (category.Keys.Contains(item.itemId))
                {
                    GameObject slotObj = category[item.itemId];
                    return (slotObj.GetComponent<InventorySlot>(),slotObj);
                }
            }
            return (null,null);
        }
        
        // Creates a item category if it doesn't exist
        private (Dictionary<String,GameObject>,GameObject) CreateCategory(System.Type category)
        {
            if (GetCategory(category) == null)
            {
                // Category gameObj
                GameObject categoryObj = new GameObject(category.Name);
                categoryObj.transform.SetParent(transform);
                _categoryGameObjects.Add(category,categoryObj);
                
                // Add category dict to inventory
                Dictionary<string, GameObject> categoryDict = new Dictionary<string, GameObject>();
                _inventory.Add(category,categoryDict);
                
                categoryCreatedEvent.Invoke(category);
                return (categoryDict,categoryObj);
            }
            return (null,null);
        }

        // Creates a item slot if it doesn't exist
        public (InventorySlot,GameObject) CreateSlot(ItemProfileSO item)
        {
            System.Type category = item.GetType();
            var cat = GetCategory(category);
            if (cat == null)
            {
                cat = CreateCategory(category).Item1;
            }
            var slotObj = GetItemSlot(item);
            if (slotObj.Item1 == null)
            {
                // Inventory slot gameObj creation
                GameObject slot = new GameObject(item.itemId);
                slot.transform.parent = _categoryGameObjects[category].transform;
                InventorySlot inventorySlot = slot.AddComponent<InventorySlot>();
                
                _inventory[category].Add(item.itemId,slot);
                inventorySlot.SetItem(item);
                
                slotCreatedEvent.Invoke(inventorySlot);
                slotObj = (inventorySlot,inventorySlot.gameObject);
            }
            return slotObj;
        }
        // Gets a component from a inventory slot gameObject 
        public T GetComponentInInventoryItem<T>(ItemProfileSO item)
        {
            return GetItemSlot(item).Item2.GetComponent<T>();
        }
        /*
         * UNSAFE FUNCTIONS
         */
        public Dictionary<string,GameObject> GetCategoryUnsafe(ItemProfileSO item)
        {
            System.Type category = item.GetType();
            if (_inventory.Keys.Contains(category))
            {
                return _inventory[category];
            }
            throw new Exception("Category not found");
        }
        
        public Dictionary<string,GameObject> GetCategoryUnsafe(System.Type category)
        {
            if (_inventory.Keys.Contains(category))
            {
                return _inventory[category];
            }
            throw new Exception("Category not found");
        }       
        private (Dictionary<String,GameObject>,GameObject) CreateCategoryUnsafe(System.Type category)
        {
            if (GetCategory(category) == null)
            {
                // Category gameObj
                GameObject categoryObj = new GameObject(category.Name);
                categoryObj.transform.SetParent(transform);
                _categoryGameObjects.Add(category,categoryObj);
                
                // Add category dict to inventory
                Dictionary<string, GameObject> categoryDict = new Dictionary<string, GameObject>();
                _inventory.Add(category,categoryDict);
                
                categoryCreatedEvent.Invoke(category);
                return (categoryDict,categoryObj);
            }
            throw new Exception("Category already exists");
        }
        public (InventorySlot,GameObject) GetItemSlotUnsafe(ItemProfileSO item)
        {
            Dictionary<string,GameObject> category = GetCategory(item);
            if (category != null)
            {
                if (category.Keys.Contains(item.itemId))
                {
                    GameObject slotObj = category[item.itemId];
                    return (slotObj.GetComponent<InventorySlot>(),slotObj);
                }
                throw new Exception("Item not found");
            }
            throw new Exception("Category not found");
        }
    }
}