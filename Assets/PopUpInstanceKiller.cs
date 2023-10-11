using UnityEngine;

public class PopUpInstanceKiller : MonoBehaviour
{
    [SerializeField] private InventoryUIState inventoryUIState;
    [SerializeField] private TileSelectionManager tileSelectionManager;
    private GameObject _popUpInstance;
    
    private void OnEnable()
    {
        inventoryUIState.inventoryUILeaveEvent.AddListener(OnLeave);
        tileSelectionManager.popUpClosedEvent.AddListener(OnPopUpClosed);
        tileSelectionManager.popUpOpenedEvent.AddListener(OnPopUpOpened);
    }
    
    private void OnDisable()
    {
        inventoryUIState.inventoryUILeaveEvent.RemoveListener(OnLeave);
        tileSelectionManager.popUpClosedEvent.RemoveListener(OnPopUpClosed);
        tileSelectionManager.popUpOpenedEvent.RemoveListener(OnPopUpOpened);
    }
    
    private void OnLeave()
    {
        if (_popUpInstance == null)
        {
            return;
        }
        print(_popUpInstance.name);
        tileSelectionManager.OnPopUpClosed();
        Destroy(_popUpInstance);
    }
    
    private void OnPopUpOpened(PopUp arg0)
    {
        _popUpInstance = arg0.gameObject;
    }

    private void OnPopUpClosed()
    {
        _popUpInstance = null;
    }

    
}
