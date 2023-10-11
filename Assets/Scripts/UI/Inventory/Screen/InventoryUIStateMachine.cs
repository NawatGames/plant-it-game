using System.Collections;
using System.Collections.Generic;
using DirtTile;
using UnityEngine;
using UnityEngine.Events;

public class InventoryUIStateMachine : MonoBehaviour
{
    [SerializeField] private InventoryUIState currentState;
    [SerializeField] private InventoryUIState initialState;
    
    public UnityEvent<InventoryUIState> currentStateChangedEvent;
    public InventoryUIState inventoryScroll;
    public InventoryUIState inventory;
    public InventoryUIState heldItemUI;
    
    private void Start(){
        if(initialState != null){
            SetState(initialState);
        }
    }
    
    [ContextMenu("Set to Inventory Scroll")]
    private void SetToInventoryScroll()
    {
        SetState(inventoryScroll);
    }
    [ContextMenu("Set to Inventory")]
    private void SetToInventory()
    {
        SetState(inventory);
    }
    [ContextMenu("Set to Held Item UI")]
    private void SetToHeldItemUI()
    {
        SetState(heldItemUI);
    }
    
    public void SetState(InventoryUIState newState)
    {
        if (currentState != null)
        {
            currentState.Leave();
        }

        currentState = newState;
        if (currentState != null)
        {
            currentState.Enter();
        }

        currentStateChangedEvent.Invoke(currentState);
    }

    public InventoryUIState GetState()
    {
        return currentState;
    }
}
