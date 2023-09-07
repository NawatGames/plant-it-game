using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class SeasonStateMachine : MonoBehaviour
{
    public UnityEvent<SeasonState> stateChangedEvent;
    [SerializeField] private SeasonState currentState;

    public void SetState(SeasonState newState)
    {
        if (currentState != null)
        {
            currentState.LeaveState();
        }
        currentState = newState;
        stateChangedEvent.Invoke(newState);
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