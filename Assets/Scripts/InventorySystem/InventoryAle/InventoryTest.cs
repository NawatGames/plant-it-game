using UnityEngine;

namespace InventorySystem.InventoryAle
{
    public class InventoryTest : MonoBehaviour
    {
        public Inventory inventory;
        public ItemProfileSO item;

        [ContextMenu("Create Slot")]
        public void Start()
        {
            var slot = inventory.GetSlot(item, true);
            slot.SetAmount(1);
        }
    }
}
