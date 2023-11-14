using UnityEngine;
using Interacts;

namespace InventorySystem.NewInventorySystem
{
    public class SlotCreator : MonoBehaviour
    {
        [SerializeField] private Inventory inventory;
        public GameObject prefab;
        public Slot CreateSlot(ItemProfileSO itemProfileSo)
        {
            // Gets reference to item category transform
            Transform parent = inventory.GetCategory(itemProfileSo.GetType()).gameObject.transform;
            
            var clone = Instantiate(prefab,parent);
            clone.name = itemProfileSo.itemId;
            Slot newSlot = clone.GetComponent<Slot>();
            newSlot.Inject(itemProfileSo);
            return newSlot;
        }
    }
}