﻿using System.Collections.Generic;
using InventorySystem.NewInventorySystem;
using Plant.LifeSystem.LifeStates;
using Tile;
using UnityEngine;

namespace Interacts
{
    
    [CreateAssetMenu(menuName = "Profile/Blank PlantCollector Item", fileName = "New Blank PlantCollector")]  
    [ItemCategory("Tool")]
    public class PlantCollectorProfileItemSO : ItemProfileSO
    {
        [SerializeField] private SeedProfileItemSO plantSeedProfileItemSo;
        
        [SerializeField]
        private List<PlantLifeStateMachine.PlantLifeStateKey> plantLifeStates = new List<PlantLifeStateMachine.PlantLifeStateKey>();
        public override bool CanInteractWith (TileHandler tileHandler)
        {
            var flag = false;
            foreach (var plantLifeKey in plantLifeStates)
            {
             
                    
                var ripeState = tileHandler.plantReference.GetHandler().plantLifeStateMachine.LocateLifeState<PlantLifeState>(plantLifeKey);
                var currentState = tileHandler.plantReference.GetHandler().plantLifeStateMachine.GetState();
                if (currentState == ripeState)
                {
                    flag = true;
                    Debug.Log("currentState==RipeState: " + flag);
                }
                
            }
            
            return flag;
        }

        public override void InteractWith(TileHandler tileHandler)
        {
            // tileHandler.plantSpawner.SpawnPlant();
        }
    }
}