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

        public void UpdateDisplay(InventorySlot inventorySlot)
        {
            _itemSprite.sprite = inventorySlot.itemProfile.inventorySprite;
            amountDisplay.text = inventorySlot.Amount().ToString();
        }
    }
}