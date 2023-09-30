using System;
using UnityEngine;
using UnityEngine.Events;

namespace UI.Inventory
{
    public class InventoryTileClicker : MonoBehaviour
    {
        public UnityEvent tileClickedEvent;

        public void Click()
        {
            tileClickedEvent.Invoke();
        }
    }
}