using System;
using UnityEngine;

namespace InventorySystem.NewInventorySystem
{
    public class CategoryCreator : MonoBehaviour
    {
        public GameObject prefab;
        public SlotCreator slotCreator;
        public Category CreateCategory(Type categoryType)
        {
            var clone = Instantiate(prefab,transform.parent);
            clone.name = categoryType.Name;
            Category newCategory = clone.GetComponent<Category>();
            newCategory.Inject(categoryType, slotCreator);
            return newCategory;
        }
    }
}