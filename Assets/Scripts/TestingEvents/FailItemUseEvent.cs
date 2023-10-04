using System.Collections;
using System.Collections.Generic;
using Tile.Inventory;
using UnityEngine;

public class FailItemUseEvent : MonoBehaviour
{
    [SerializeField] private TileItemUser tileItemUser;
    
    private void OnEnable()
    {
        tileItemUser.itemUseFail.AddListener(OnItemUseFail);
    }
    
    private void OnDisable()
    {
        tileItemUser.itemUseFail.RemoveListener(OnItemUseFail);
    }   
    
    private void OnItemUseFail()
    {
        Debug.Log("Item use fail");
    }
}
