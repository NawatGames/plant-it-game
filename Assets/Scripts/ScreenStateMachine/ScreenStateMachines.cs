﻿using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ScreenStateMachines : MonoBehaviour
{
    public UnityEvent<ScreenState> stateChangedEvent;
    private ScreenState currentState;
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

    public ScreenState GetState()
    {
        return currentState;
    }

    [ContextMenu("refresh")]
    public void Refresh()
    {
        SetState(nextState);
    }
}