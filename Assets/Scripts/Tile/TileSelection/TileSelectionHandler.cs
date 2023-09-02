using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace UI.PopUp
{
    public class TileSelectionHandler : MonoBehaviour
    {
        public GameObject popUpPrefab;
        
        public UnityEvent selectedEvent; 
        public UnityEvent unselectedEvent;
        
        public virtual void Select()
        {
            selectedEvent.Invoke();
        }

        public virtual void Unselect()
        {
            unselectedEvent.Invoke();
        }
    }
}