using System.Collections;
using System.Collections.Generic;
using GrowSystem.PlantInteracts;
using Handler;
using UnityEngine;


namespace Interacts
{
    [CreateAssetMenu(menuName = "Profile/Blank Seed Item", fileName = "New Blank Seed")]
    public class SeedProfileItemSO : ItemProfileSO
    {
        [SerializeField] private SeedProfileItemSO plant;

        public override bool CanInteractWith (TileHandler tileHandler)
        {
            if(tileHandler.plantReference.GetHandler() != null)
            {   
                Debug.Log("PlantHandler found ");
                return false;
            }
            Debug.Log("PlantHandler not found ");
            return true;
        }

        public override void InteractWith(TileHandler tileHandler)
        {
            // tileHandler.plantSpawner.SpawnPlant();
        }
    }
}