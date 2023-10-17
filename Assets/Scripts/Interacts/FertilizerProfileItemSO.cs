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
       

        [SerializeField]
        private List<NutrientLocator.NutrientKey> nutrients = new List<NutrientLocator.NutrientKey>();
        public override bool CanInteractWith (TileHandler tileHandler)
        {   var flag = false;
            
            foreach (var nutrientKey in nutrients)
            {
                var tileHandlerTileNutrientLocator = tileHandler.tileNutrientLocator;
                var locateNutrient = tileHandlerTileNutrientLocator.LocateNutrient<TileNutrient>(nutrientKey);
                Debug.Log("tileHandlerTileNutrientLocator: " + tileHandlerTileNutrientLocator);
                Debug.Log("locateNutrient: " + locateNutrient);
                bool isFull = locateNutrient.IsFull();
                Debug.Log("locateNutrient.IsFull(): " + isFull);
                if (isFull == false)
                {
                    flag = true;
                    Debug.Log("flag: " + flag);
                    Debug.Log("nutrientKey: " + nutrientKey);
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