using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUISelectionImageUpdater : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text quantity;
    [SerializeField] private InventoryUiSelectionManager inventoryUiSelectionManager;

    private void OnEnable()
    {
        inventoryUiSelectionManager.selectItemEvent.AddListener(OnSelectItem);
    }

    private void OnDisable()
    {
        inventoryUiSelectionManager.selectItemEvent.RemoveListener(OnSelectItem);
    }
    
    private void OnSelectItem(InventoryUIItem arg0)
    {
        image.sprite = arg0.itemImage.sprite;
        quantity.text = $"x{arg0.quantity}";
    }
}