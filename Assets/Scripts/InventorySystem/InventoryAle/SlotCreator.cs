using UnityEngine;

namespace InventorySystem.InventoryAle
{
    public class SlotCreator : MonoBehaviour
    {
        public GameObject prefab;
        public Slot CreateSlot(string itemId)
        {
            var clone = Instantiate(prefab);
            Slot newSlot = clone.GetComponent<Slot>();
            return newSlot;
        }
    }
}