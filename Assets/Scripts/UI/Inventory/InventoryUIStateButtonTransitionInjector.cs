using UnityEngine;

public class InventoryUIStateButtonTransitionInjector : MonoBehaviour
{
    [SerializeField] private InventoryUIStateButtonTransition inventoryUIStateButtonTransition;
        
    private void Awake()
    {
        var inventoryUIStateMachine = FindObjectOfType<InventoryUIStateMachine>();
        var nextState = inventoryUIStateMachine.heldItemUI;
        
        inventoryUIStateButtonTransition.inventoryUIStateMachine = inventoryUIStateMachine;
        inventoryUIStateButtonTransition.nextState = nextState;
    }
    
}