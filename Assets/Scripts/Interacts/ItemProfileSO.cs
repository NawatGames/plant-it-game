using System;
using Tile;
using UnityEngine;
using UnityEngine.Events;
using InventorySystem.NewInventorySystem;
using UnityEditor;

namespace Interacts
{
    [CreateAssetMenu(menuName = "Profile/Blank Item", fileName = "New Profile")]
    [ItemCategory("No assigned category")]
    public class ItemProfileSO : ScriptableObject
    {
        public GameObject prefab;
        public UnityEvent itemSelectEvent, itemUnselectEvent;

        public string itemId = "";
        public Sprite inventorySprite;
        public bool consumable = true;

        public virtual bool CanInteractWith(TileHandler selectedTile)
        {
            return true;
        }
        public virtual void InteractWith(TileHandler selectedTile)
        {
        
        }
        
    }
}
