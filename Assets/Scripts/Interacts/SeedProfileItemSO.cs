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
       
        [SerializeField] private GameObject plantPrefab;
       
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
            PlantHandler plantHandler = tileHandler.plantSpawner.SpawnPlant(plantPrefab);
            tileHandler.plantReference.SetHandler(plantHandler);
            tileHandler.plantSpawner.InjectPlantData(plantHandler);
            
        }
    }
}