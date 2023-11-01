using System.Collections;
using System.Collections.Generic;
using Handler;
using InventorySystem;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Profile/Blank Item", fileName = "New Profile")]
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
