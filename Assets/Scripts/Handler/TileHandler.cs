using GrowSystem.PlantInteracts;
using System;
using InventorySystem;
using KevinCastejon.MoreAttributes;
using Tile.Inventory;
using UnityEngine;
using UnityEngine.Serialization;

namespace Handler
{
    public class TileHandler : MonoBehaviour
    {
        public InventoryTileClicker tileClicker;
        public NutrientLocator tileNutrientLocator;
        public PlantSpawner plantSpawner;
        public PlantRemover plantRemover;
        public PlantReference plantReference;
    }   
}