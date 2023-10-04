using UnityEngine;

public class InventoryUIStateAlignedEnabler : MonoBehaviour
{
    [SerializeField] private InventoryUIState inventoryUIState;
    [SerializeField] private GameObject target;
    
    private void OnEnable()
    {
        inventoryUIState.inventoryUIEnterEvent.AddListener(OnEnter);
        inventoryUIState.inventoryUILeaveEvent.AddListener(OnLeave);
    }

    private void OnDisable()
    {
        inventoryUIState.inventoryUIEnterEvent.RemoveListener(OnEnter);
        inventoryUIState.inventoryUILeaveEvent.RemoveListener(OnLeave);
    }

    private void OnEnter()
    {
        target.SetActive(true);
        
    }

    private void OnLeave()
    {
        target.SetActive(false);
        
    }
}
