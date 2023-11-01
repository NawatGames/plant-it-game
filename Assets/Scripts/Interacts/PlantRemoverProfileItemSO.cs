using System.Collections;
using System.Collections.Generic;
using GrowSystem.PlantInteracts;
using Handler;
using UnityEngine;

namespace Interacts
{       
    [CreateAssetMenu(menuName = "Profile/Blank PlantRemover Item", fileName = "New Blank PlantRemover")]
    public class PlantRemoverProfileItemSO : ItemProfileSO
    {
        
        public override bool CanInteractWith (TileHandler tileHandler)
        {   
            if(tileHandler.plantReference.GetHandler() == null)
            {
                Debug.Log("PlantHandler not found ");
                return false;
            }
            Debug.Log("PlantHandler found ");
            return true;
        }

        public override void InteractWith(TileHandler tileHandler)
        {
            GameObject plant = tileHandler.plantReference.GetHandler().transform.parent.gameObject;
            Debug.Log("Plant to be removed"+ plant);
            tileHandler.plantRemover.RemovePlant(plant);


        }
    }
}
