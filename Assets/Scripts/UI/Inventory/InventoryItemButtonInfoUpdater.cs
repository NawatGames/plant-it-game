using System;
using InventorySystem;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace UI.Inventory
{
    public class InventoryItemButtonInfoUpdater : MonoBehaviour
    {
        [SerializeField] private Image _itemSprite;
        [SerializeField] private TMP_Text amountDisplay;
        public InventorySlot slot;

        private void OnEnable()
        {
            UpdateDisplay();
        }

        public void SetSlot(InventorySlot inventorySlot)
        {
            slot = inventorySlot;
            UpdateDisplay();
        }
        public void UpdateDisplay()
        {
            _itemSprite.sprite = slot.itemProfile.inventorySprite;
            amountDisplay.text = slot.Amount().ToString();
        }
    }
}