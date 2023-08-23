using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SeasonStateMachine : MonoBehaviour
{
    public UnityEvent<SeasonState> StateChangedEvent;
    [SerializeField] private SeasonState currentState;

    public void SetState(SeasonState newState)
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

    public SeasonState GetState()
    {
        return currentState;
    }
}