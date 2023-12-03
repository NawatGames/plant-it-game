using System;
using UnityEngine;

namespace InventorySystem.NewInventorySystem
{
    public class CategoryCreator : MonoBehaviour
    {
        public GameObject prefab;
        public SlotCreator slotCreator;
        public Category CreateCategory(string categoryName)
        {
            var clone = Instantiate(prefab,transform.parent);
            clone.name = categoryName;
            Category newCategory = clone.GetComponent<Category>();
            newCategory.Inject(categoryName, slotCreator);
            return newCategory;
        }
    }
}