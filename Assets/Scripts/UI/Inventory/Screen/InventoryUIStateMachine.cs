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
