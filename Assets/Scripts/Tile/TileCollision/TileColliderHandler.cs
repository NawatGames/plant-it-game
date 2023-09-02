using UnityEngine;
using UnityEngine.Events;


public class TileColliderHandler : MonoBehaviour
{
    public UnityEvent mouseEnteringEvent;
    public UnityEvent mouseExitingEvent;
    
    public void OnMouseEnter()
    {
        mouseEnteringEvent.Invoke();
    }

    public void OnMouseExit()
    {
        mouseExitingEvent.Invoke();
    }
}
