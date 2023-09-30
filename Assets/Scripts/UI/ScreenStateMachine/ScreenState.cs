using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ScreenState : MonoBehaviour
{
    public UnityEvent stateEnteredEvent;
    public UnityEvent stateLeavedEvent;
		
    [ContextMenu("OnEnterState")]
    public virtual void EnterState(){
        stateEnteredEvent.Invoke();
    }

    [ContextMenu("OnExitState")]
    public virtual void LeaveState(){
        stateLeavedEvent.Invoke();
    }
}