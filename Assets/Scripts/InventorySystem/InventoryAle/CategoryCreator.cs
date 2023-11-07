using System;
using UnityEngine;

namespace InventorySystem.InventoryAle
{
    public class CategoryCreator : MonoBehaviour
    {
        public GameObject prefab;
        public Category CreateCategory(Type categoryType)
        {
            var clone = Instantiate(prefab);
            Category newCategory = clone.GetComponent<Category>();
            return newCategory;
        }
    }
}