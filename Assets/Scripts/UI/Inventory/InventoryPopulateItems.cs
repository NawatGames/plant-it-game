using System;
using InventorySystem;
using UnityEngine;

namespace UI.Inventory
{
    public class InventoryPopulateItems : MonoBehaviour
    {
        [SerializeField] private GameObject _itemHolder;
        [SerializeField] private GameObject _slotDisplayTemplate;
        [SerializeField] private InventoryManager _inventoryManager;

        private void OnEnable()
        {
            foreach (InventorySlot item in _inventoryManager.GetInventory())
            {
                GameObject slot = Instantiate(_slotDisplayTemplate, _itemHolder.transform);
                slot.GetComponent<InventoryItemButtonInfoUpdater>().SetSlot(item);
            }
        }

        private void OnDisable()
        {
            foreach (Transform child in _itemHolder.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}