using System;
using UnityEngine;

namespace InventorySystem.NewInventorySystem
{
    /// <summary>
    /// Item Category, defines an item category name
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ItemCategory : Attribute
    {
        public string CategoryName { get; set; }
        public ItemCategory(string name)
        {
            CategoryName = name;
        }
    }
}