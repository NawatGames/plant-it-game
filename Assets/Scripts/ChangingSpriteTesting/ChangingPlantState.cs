using System;
using System.Collections.Generic;
using UnityEngine;

namespace ChangingSpriteTesting
{   
    [Serializable]
    public class PlantInfo
    {
        
        public PlantState plantState;
        public Sprite sprite;
    }
    
    public class ChangingPlantState : MonoBehaviour
    {

        public List<PlantInfo> plantInfos;
        
        private void OnEnable()
        {
            // foreach (var plantInfo in plantInfos)
            // {
            //     plantInfo.plantState.stateEnteredEvent.AddListener();
            //     plantInfo.plantState.stateLeavedEvent.AddListener();
            //     plantInfo.plantLifeState.stateEnteredEvent.AddListener();
            //     plantInfo.plantLifeState.stateLeavedEvent.AddListener();
            //     
            // }
        }

        private void OnDisable()
        {
            // foreach (var plantInfo in plantInfos)
            // {
            //     plantInfo.plantState.stateLeavedEvent.AddListener();
            //     plantInfo.plantLifeState.stateLeavedEvent.AddListener();
            // }
            
        }
    }
}
