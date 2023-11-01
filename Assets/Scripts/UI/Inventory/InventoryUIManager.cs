using System;
using System.Collections.Generic;
using InventorySystem;
using UI.Inventory;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI.Inventory
{
    public class InventoryUIManager : MonoBehaviour
    {
        private Dictionary<InventorySlot, GameObject> _slots = new Dictionary<InventorySlot, GameObject>();
        private Dictionary<System.Type, GameObject> _categories = new Dictionary<Type, GameObject>();
        [SerializeField] private InventoryManagerNew inventoryManager;
        
        [SerializeField] private GameObject _inventoryScreenContentHolder;
        [SerializeField] private GameObject _inventoryUISlotTemplate;
        [SerializeField] private GameObject _inventoryUICategoryTemplate;

        private void OnEnable()
        {
            inventoryManager.categoryCreatedEvent.AddListener(CreateCategoryObj);
            inventoryManager.slotCreatedEvent.AddListener(CreateUISlot);
            inventoryManager.slotDeletedEvent.AddListener(DeleteUISlot);
        }

        private void OnDisable()
        {
            inventoryManager.slotCreatedEvent.RemoveListener(CreateUISlot);
            inventoryManager.slotDeletedEvent.RemoveListener(DeleteUISlot);
        }

        private void CreateCategoryObj(System.Type category)
        {
            GameObject categoryObj = Instantiate(_inventoryUICategoryTemplate, _inventoryScreenContentHolder.transform);
            categoryObj.name = category.ToString();
            _categories.Add(category,categoryObj);
        }

        private void DeleteCategoryObj(System.Type category)
        {
            
        }
        
        private void CreateUISlot(InventorySlot slot)
        {
            // Creates UI slot gameObj
            Transform parent = _categories[slot.itemProfile.GetType()].transform;
            GameObject slotUI = Instantiate(_inventoryUISlotTemplate, parent);
            _slots.Add(slot, slotUI);
            
            // Updates UI slot display
            slotUI.GetComponent<InventoryItemButtonInfoUpdater>().SetSlot(slot);
        }

        private void DeleteUISlot(InventorySlot slot)
        {
            // Destroys display slot
            GameObject slotUI = _slots[slot];
            Destroy(slotUI);
        }
    }
}