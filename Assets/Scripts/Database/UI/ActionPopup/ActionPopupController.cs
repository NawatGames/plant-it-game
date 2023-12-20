using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Database.UI.ActionPopup
{
    public class ActionPopupController : MonoBehaviour
    {
        public UnityEvent actionOpenPopupEvent;
        public UnityEvent closePopupEvent;
    }
}