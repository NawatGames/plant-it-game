using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HibernationStateMachine : MonoBehaviour
{
    public UnityEvent<HibernationState> StateChangedEvent;
    [SerializeField] private HibernationState currentState;

    public void SetState(HibernationState newState)
    {
        if (currentState != null) currentState.LeaveState();
        currentState = newState;
        StateChangedEvent.Invoke(newState);
        if (currentState != null) currentState.EnterState();
    }
    public HibernationState GetState()
    {
        return currentState;
    }
}
