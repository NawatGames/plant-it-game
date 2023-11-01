using UnityEngine;

public class InventoryPopUpInstanceKiller : MonoBehaviour
{
    [SerializeField] private InventoryUIState inventoryUIState;
    [SerializeField] private InventoryPopUpManager inventoryPopUpManager;
    private GameObject _popUpInstance;
    
    private void OnEnable()
    {
        inventoryUIState.inventoryUILeaveEvent.AddListener(OnLeave);
        inventoryPopUpManager.inventoryPopUpClosedEvent.AddListener(OnInventoryPopUpClosed);
        inventoryPopUpManager.inventoryPopUpOpenedEvent.AddListener(OnInventoryPopUpOpened);
    }
    
    private void OnDisable()
    {
        inventoryUIState.inventoryUILeaveEvent.RemoveListener(OnLeave);
        inventoryPopUpManager.inventoryPopUpClosedEvent.RemoveListener(OnInventoryPopUpClosed);
        inventoryPopUpManager.inventoryPopUpOpenedEvent.RemoveListener(OnInventoryPopUpOpened);
    }
    
    private void OnLeave()
    {
        if (_popUpInstance == null)
        {
            return;
        }
        print(_popUpInstance.name);
        Destroy(_popUpInstance);
        inventoryPopUpManager.OnInventoryPopUpClosed();
    }
    
    private void OnInventoryPopUpOpened(InventoryPopUp arg0)
    {
        _popUpInstance = arg0.gameObject;
    }

    private void OnInventoryPopUpClosed()
    {
        _popUpInstance = null;
    }
}