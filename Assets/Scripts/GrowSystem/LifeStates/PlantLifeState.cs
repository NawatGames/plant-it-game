using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlantLifeState : MonoBehaviour
{
    public UnityEvent stateEnteredEvent;
    public UnityEvent stateLeavedEvent;

    public virtual void EnterState()
    {
        stateEnteredEvent.Invoke();
    }
    
    
    public virtual void LeaveState()
    {
        stateLeavedEvent.Invoke();
    }
}

//State Machine, unica responsabilidade da classe é ter um unico estado atual
