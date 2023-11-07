using UnityEngine;

namespace InventorySystem.InventoryAle
{
    public class SlotCreator : MonoBehaviour
    {
        public GameObject prefab;
        public Slot CreateSlot(ItemProfileSO itemProfileSo)
        {
            var clone = Instantiate(prefab);
            Slot newSlot = clone.GetComponent<Slot>();
            newSlot.Inject(itemProfileSo);
            return newSlot;
        }
    }
}