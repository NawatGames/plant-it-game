using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace InventorySystem
{
    public class InventoryManager : MonoBehaviour
    {
        private Dictionary<string, GameObject> _inventory = new Dictionary<string, GameObject>();
        [SerializeField] private InventorySlot _slotTemplate;
        [SerializeField] private ItemProfileSO[] test;
        private void Awake()
        {
            foreach (var item in test)
            {
                AddItem(item);
                GetItem(item).SetAmount(Random.Range(1,1000));
            }
        }

        public void AddItem(ItemProfileSO item)
        {
            if (!_inventory.Keys.Contains(item.itemId))
            {
                Debug.Log("Inventory created item slot");
                _inventory[item.itemId] = Instantiate(_slotTemplate.gameObject, transform);
                GetItem(item).SetItem(item);
                GetItem(item).slotDeletedEvent.AddListener(RemoveItem);
            }
        }
        public T GetComponentInItem<T>(ItemProfileSO item)
        {
            return GetItem(item).GetComponent<T>();
        }
        public InventorySlot GetItem(ItemProfileSO item)
        {
            if (_inventory[item.itemId] != null)
            {
                return _inventory[item.itemId].GetComponent<InventorySlot>();
            }
            Debug.Log("Inventory manager returned null");
            return null;
        }
        
        public InventorySlot[] GetInventory()
        {
            return _inventory.Values.Select(item => item.GetComponent<InventorySlot>()).ToArray();
        }

        public void RemoveItem(InventorySlot item)
        {
            if (_inventory[item.itemId] != null)
            {
                _inventory.Remove(item.itemId);
            }
        }
    }
}