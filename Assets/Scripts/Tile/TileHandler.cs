using Handler;
using Tile.Inventory;
using Tile.PlantInteracts;
using UnityEngine;

namespace Tile
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