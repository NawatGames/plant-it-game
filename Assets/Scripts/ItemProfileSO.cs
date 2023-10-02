using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Profile/Blank Item", fileName = "New Profile")]
public class ItemProfileSO : ScriptableObject
{
    public GameObject prefab;
    public UnityEvent itemSelectEvent, itemUnselectEvent;

    public virtual bool CanInteractWith(TileHandler selectedTile)
    {
        return false;
    }
    public virtual void InteractWith(TileHandler selectedTile)
    {
        
    }
}