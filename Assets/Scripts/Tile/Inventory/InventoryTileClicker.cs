using UnityEngine;
using UnityEngine.Events;

namespace Tile.Inventory
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