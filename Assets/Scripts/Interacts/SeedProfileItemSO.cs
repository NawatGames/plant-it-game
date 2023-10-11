using System.Collections;
using System.Collections.Generic;
using GrowSystem.PlantInteracts;
using Handler;
using UnityEngine;


namespace Interacts
{
    public class SeedProfileItemSO : ItemProfileSO
    {
        [SerializeField] private SeedProfileItemSO plant;

        public override bool CanInteractWith (TileHandler tileHandler)
        {
            return true;
        }

        public override void InteractWith(TileHandler tileHandler)
        {
            tileHandler.plantSpawner.SpawnPlant();
        }
    }
}