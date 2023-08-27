using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlantStateMachine : MonoBehaviour
{
    public UnityEvent<PlantState> StateChangedEvent;
    [SerializeField] private PlantState currentState;

    public void SetState(PlantState newState)
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

    public PlantState GetState() 
    {
        return currentState;
    }
}
