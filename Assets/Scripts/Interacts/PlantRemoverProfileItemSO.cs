using System.Collections;
using System.Collections.Generic;
using GrowSystem.PlantInteracts;
using Handler;
using UnityEngine;

namespace Interacts
{
    public class PlantRemoverProfileItemSO : ItemProfileSO
    {
        [SerializeField] private SeedProfileItemSO plant;
        public override bool CanInteractWith (TileHandler tileHandler)
        {
            return true;
        }

        public override void InteractWith(TileHandler tileHandler)
        {
            tileHandler.plantRemover.RemovePlant();
            
        }
    }
}
