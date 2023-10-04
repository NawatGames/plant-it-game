using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlantGrowingState : MonoBehaviour
{
    public UnityEvent stateEnterEvent;
    public UnityEvent stateExitEvent;
		
    [ContextMenu("OnEnterState")]
    public virtual void EnterState()
    {
        stateEnterEvent.Invoke();
    }

    [ContextMenu("OnExitState")]
    public virtual void ExitState()
    {
        stateExitEvent.Invoke();
    }
}

//State Machine, unica responsabilidade da classe é ter um unico estado atual