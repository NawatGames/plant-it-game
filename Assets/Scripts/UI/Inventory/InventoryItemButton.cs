using System;
using Interacts;
using InventorySystem;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Inventory
{
    public class InventoryItemButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private ItemProfileSO itemProfileSo;
        [FormerlySerializedAs("inventoryItemSelectionManager")] [SerializeField] private ItemSelectionManager itemSelectionManager;
        
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
            itemSelectionManager.SetState(itemProfileSo);
        }
    }
}