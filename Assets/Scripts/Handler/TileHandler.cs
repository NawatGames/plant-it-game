using GrowSystem.PlantInteracts;
using Tile.Inventory;
using UnityEngine;

namespace Handler

{
    public class TileHandler : MonoBehaviour
    {
        public InventoryTileClicker tileClicker;
        public NutrientLocator tileNutrientLocator;
        public PlantSpawner plantSpawner;
        public PlantRemover plantRemover;
    }
}