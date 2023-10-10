using System;
using InventorySystem;
using KevinCastejon.MoreAttributes;
using Tile.Inventory;
using UnityEngine;
using UnityEngine.Serialization;

public class TileHandler : MonoBehaviour
{
    public InventoryTileClicker tileClicker;
    public NutrientLocator tileNutrientLocator;
    public int exist = 0;
    

    private void Start()
    {
        Transform tileTransform = transform.parent;
        ExistPlant existPlant = GetComponentInChildren<ExistPlant>();
        if (existPlant == null)
            return;
        else
        {
            exist = 1;
        }
    }
    
}


