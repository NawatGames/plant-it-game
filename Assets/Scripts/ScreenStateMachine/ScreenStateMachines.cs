using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ScreenStateMachines : MonoBehaviour
{
    public UnityEvent<ScreenState> StateChangedEvent;
    private ScreenState _currentState;
    [SerializeField] private ScreenState nextState;
    [SerializeField] private ScreenState initialState;

    public void Start()
    {
        if (initialState != null)
        {
            SetState(initialState);
        }
    }
    
    public void SetState(ScreenState newState)
    {
        if (_currentState != null)
        {
            _currentState.LeaveState();
        }
        _currentState = newState;
        StateChangedEvent.Invoke(newState);
        if (_currentState != null)
        {
            _currentState.EnterState();
        }
    }

    public ScreenState GetState()
    {
        return _currentState;
    }

    [ContextMenu("refresh")]
    public void Refresh()
    {
        SetState(nextState);
    }
}