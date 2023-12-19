using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace Database.UI.InfoPopup
{
    public class InfoPopupController : MonoBehaviour
    {
        public UnityEvent openPopupEvent;
        public UnityEvent closePopupEvent;
    }
}