using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlantLifeStateMachine : MonoBehaviour
{
    [SerializeField] private PlantLifeState currentState;
    public UnityEvent<PlantLifeState> StateChangedEvent;
    
    public void SetState(PlantLifeState newState)
    {
        if (currentState != null)
        {
            currentState.LeaveState();
        }
        
        currentState = newState;
        StateChangedEvent.Invoke(newState);
        
        if (currentState != null)
        {
            currentState.EnterState();
        }
    }
    
    public PlantLifeState GetState()
    {
        return currentState;
    }
}
