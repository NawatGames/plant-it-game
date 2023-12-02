using UnityEngine;
using Interacts;

namespace InventorySystem.NewInventorySystem
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
