using System;
using KevinCastejon.MoreAttributes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlantGrowingStateMachine : MonoBehaviour
{
    [SerializeField][ReadOnly] private PlantGrowingState currentGrowingState;
    [SerializeField][ReadOnlyOnPlay] private PlantGrowingState initialState;
    [SerializeField] private PlantGrowingState nextState;

    public UnityEvent<PlantGrowingState, PlantGrowingState> stateChangedEvent;

    private void Start()
    {
        if (initialState != null)
        {
            ChangeState(initialState);
        }
    }

    public void ChangeState(PlantGrowingState newState)
    {
        var oldState = currentGrowingState;

        if (currentGrowingState != null)
        {
            currentGrowingState.ExitState();
        }

        currentGrowingState = newState;

        if (currentGrowingState != null)
        {
            currentGrowingState.EnterState();
        }

        stateChangedEvent.Invoke(newState, oldState);
    }
    
    public PlantGrowingState GetState()
    {
        return currentGrowingState;
    }

    [ContextMenu("SetNextState")]
    private void SetNextState()
    {
        ChangeState(nextState);
    }
}