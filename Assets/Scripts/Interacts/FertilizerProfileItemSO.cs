using System;
using System.Collections;
using System.Collections.Generic;
using GrowSystem.PlantInteracts;
using Handler;
using UnityEngine;

namespace Interacts
{
    [CreateAssetMenu(menuName = "Profile/Blank Fertilizer Item", fileName = "New Blank Fertilizer")]
    public class FertilizerProfileItemSO : ItemProfileSO
    {
       [Serializable] class NutrientKeyPair
       {
           public NutrientLocator.NutrientKey nutrientKey;
           [Range(0f,1f)] public float amount;
           
       }

        [SerializeField]
        private List<NutrientKeyPair> nutrients = new List<NutrientKeyPair>();
        public override bool CanInteractWith (TileHandler tileHandler)
        {   var flag = false;
            
            foreach (var nutrientKeyPair in nutrients)
            {
                var tileHandlerTileNutrientLocator = tileHandler.tileNutrientLocator;
                var locateNutrient = tileHandlerTileNutrientLocator.LocateNutrient<TileNutrient>(nutrientKeyPair.nutrientKey);
                Debug.Log("tileHandlerTileNutrientLocator: " + tileHandlerTileNutrientLocator);
                Debug.Log("locateNutrient: " + locateNutrient);
                bool isFull = locateNutrient.IsFull();
                Debug.Log("locateNutrient.IsFull(): " + isFull);
                if (isFull == false)
                {
                    flag = true;
                    Debug.Log("flag: " + flag);
                    Debug.Log("nutrientKey: " + nutrientKeyPair.nutrientKey);
                }
                
            }
            
            Debug.Log("CanInteractWith: " + flag);
            return flag;
        }

        public override void InteractWith(TileHandler tileHandler)
        {
            // tileHandler.plantSpawner.SpawnPlant();
        }
    }
}