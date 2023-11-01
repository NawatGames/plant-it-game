using System.Collections;
using System.Collections.Generic;
using KevinCastejon.MoreAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlantLifeStateMachine : MonoBehaviour
{
    [SerializeField][ReadOnly] private PlantLifeState currentLifeState;
    [SerializeField][ReadOnlyOnPlay] private PlantLifeState initialState;
    [SerializeField] private PlantLifeState nextState;
    public PlantLifeState CurrentLifeState => currentLifeState;

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

    public PlantLifeState GetState()
    {
        Debug.Log("current state: " + currentLifeState);
        return currentLifeState;
        
    }
    
    public enum PlantLifeStateKey
    {
        Growing,
        Ripe,
        Decomposed,
        Dead,
        Hibernating,
        Dying

    }
    
    public T LocateLifeState<T>(PlantLifeStateKey key)
    {
        Debug.Log(key.ToString());
        return transform.Find(key.ToString()).GetComponent<T>();
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