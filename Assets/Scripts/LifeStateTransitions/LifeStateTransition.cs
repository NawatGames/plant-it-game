using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeStateTransition : MonoBehaviour
{
    [SerializeField] protected PlantLifeState fromState;
    [SerializeField] protected PlantLifeStateMachine lifeStateMachine;
    protected PlantLifeState growing;
    protected PlantLifeState hibernating;
    protected PlantLifeState decomposed;
    protected PlantLifeState dying;
    protected PlantLifeState ripe;
    protected PlantLifeState dead;

    private void Awake()
    {
        growing = lifeStateMachine.gameObject.transform.Find("Growing").GetComponent<PlantLifeState>();
        hibernating = lifeStateMachine.gameObject.transform.Find("Hibernating").GetComponent<PlantLifeState>();
        decomposed = lifeStateMachine.gameObject.transform.Find("Decomposed").GetComponent<PlantLifeState>();
        dying = lifeStateMachine.gameObject.transform.Find("Dying").GetComponent<PlantLifeState>();
        ripe = lifeStateMachine.gameObject.transform.Find("Ripe").GetComponent<PlantLifeState>();
        dead = lifeStateMachine.gameObject.transform.Find("Dead").GetComponent<PlantLifeState>();
    }

    protected virtual void OnEnable()
    {
        fromState.stateEnteredEvent.AddListener(OnStateEntered);
        fromState.stateLeavedEvent.AddListener(OnStateLeft);
    }
    
    protected virtual void OnDisable()
    {
        fromState.stateEnteredEvent.AddListener(OnStateEntered);
        fromState.stateLeavedEvent.AddListener(OnStateLeft);
    }

    protected virtual void OnStateEntered()
    {
        
    }

    protected virtual void OnStateLeft()
    {
        
    }
}
