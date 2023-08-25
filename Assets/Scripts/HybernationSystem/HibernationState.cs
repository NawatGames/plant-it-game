using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HibernationState : MonoBehaviour
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
