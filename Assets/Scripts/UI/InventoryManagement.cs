using UnityEngine;

public class InventoryManagement : MonoBehaviour
{
    [SerializeField] private GameObject heldItem;
    [SerializeField] private GameObject inventory;

    public void OpenInventory()
    {
        heldItem.SetActive(false);
        inventory.SetActive(true);
    }

    public void CloseInventory()
    {
        heldItem.SetActive(true);
        inventory.SetActive(false);
    }
}