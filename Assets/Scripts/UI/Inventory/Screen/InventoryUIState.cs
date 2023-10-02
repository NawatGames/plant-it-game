using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class InventoryUIState : MonoBehaviour
{
    public UnityEvent inventoryUIEnterEvent;
    public UnityEvent inventoryUILeaveEvent;

    public virtual void Enter()
    {
        inventoryUIEnterEvent.Invoke();
    }

    public virtual void Leave()
    {
        inventoryUILeaveEvent.Invoke();
    }
    
}
