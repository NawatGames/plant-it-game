using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SeasonState : MonoBehaviour
{
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