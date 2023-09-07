using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlantLifeStateMachine : MonoBehaviour
{
    [SerializeField] private PlantLifeState currentLifeState;
    [SerializeField] private PlantLifeState initialState;
    [SerializeField] private PlantLifeState nextState;

    public UnityEvent<PlantLifeState, PlantLifeState> stateChangedEvent;

    private void Start()
    {
        if (initialState != null)
        {
            ChangeState(initialState);
        }
    }

    public void ChangeState(PlantLifeState newState)
    {
        var oldState = currentLifeState;

        if (currentLifeState != null)
        {
            currentLifeState.LeaveState();
        }

        currentLifeState = newState;

        if (currentLifeState != null)
        {
            currentLifeState.EnterState();
        }

        stateChangedEvent.Invoke(newState, oldState);
    }

    [ContextMenu("SetNextState")]
    private void SetNextState()
    {
        ChangeState(nextState);
    }

    public void SetState(PlantLifeState hibernatingState)
    {
        throw new System.NotImplementedException();
    }
}