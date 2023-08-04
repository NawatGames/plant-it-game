using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlantState : MonoBehaviour
{
    public string stateName;
    public UnityEvent stateEnteredEvent;
    public UnityEvent stateLeavedEvent;

    public void EnterState()
    {
        stateEnteredEvent.Invoke();
    }
    
    
    public void LeaveState()
    {
        stateLeavedEvent.Invoke();
    }
}

//State Machine, unica responsabilidade da classe é ter um unico estado atual
