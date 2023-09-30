using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Inventory
{
    public class InventoryItemButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private ItemProfileSO itemProfileSo;
        [SerializeField] private InventoryItemSelectionManager inventoryItemSelectionManager;
        
        private void OnEnable()
        {
            button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(OnButtonClick);
        }

        void OnButtonClick()
        {
            inventoryItemSelectionManager.SetState(itemProfileSo);
        }
    }
}