using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Database.UI.ActionPopup
{
    public class ActionPopupController : MonoBehaviour, IPointerClickHandler
    {
        public UnityEvent actionOpenPopupEvent;
        public UnityEvent closePopupEvent;
        public void OnPointerClick(PointerEventData eventData)
        {
            actionOpenPopupEvent.Invoke();
            Debug.Log("OpenPopup");
            
        }
    }
}