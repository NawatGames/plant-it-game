using UnityEngine;


public class InventoryPopUpBuilder : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPopUpPrefab;
    [SerializeField] private Transform canvas;
    [SerializeField] private Vector3Int inventoryPopUpOffset;

    public InventoryPopUp BuildPopUp(InventoryPopUpHandler inventoryPopUpHandler)
    {
        var prefab = inventoryPopUpPrefab;
        if (inventoryPopUpHandler.inventoryPopUpPrefab != null) prefab = inventoryPopUpHandler.inventoryPopUpPrefab;

        GameObject instance = Instantiate(prefab, canvas);

        var position = inventoryPopUpHandler.transform.position;

        instance.transform.position = position;

        var inventoryPopUp = instance.GetComponent<InventoryPopUp>();
        if (inventoryPopUp == null) Debug.LogError("PopUp prefab does not have InventoryPopUp component");
        return inventoryPopUp;
    }
}
