using UnityEngine;
using UnityEngine.Events;

public class SelectedItemState : MonoBehaviour
{
    public UnityEvent enterEvent; 
    public UnityEvent leaveEvent;
    public virtual void Enter()
    {
        enterEvent.Invoke();
    }

    public virtual void Leave()
    {
        leaveEvent.Invoke();
    }
}
