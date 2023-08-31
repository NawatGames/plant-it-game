using System;
using System.Collections.Generic;
using UnityEngine;

namespace ChangingSpriteTesting
{
    [Serializable]
    public class PlantInfo
    {
        public PlantState plantState;
        public PlantLifeState plantLifeState;
        public SpriteUpdater spriteUpdater;
    }

    public class ChangingPlantState : MonoBehaviour
    {
        public List<PlantInfo> plantInfos;
        public PlantStateMachine plantStateMachine;
        public PlantLifeStateMachine plantLifeStateMachine;

        private void OnEnable()
        {
            plantStateMachine.StateChangedEvent.AddListener(OnPlantStateChanged);
        }

        private void OnDisable()
        {
            plantStateMachine.StateChangedEvent.RemoveListener(OnPlantStateChanged);
        }

        private void OnPlantStateChanged(PlantState newState)
        {
            int foundState = CheckingPlantState(newState);
            if (foundState != -1)
            {
                plantInfos[foundState].spriteUpdater.UpdateSprite();
            }
            else
            {
                Debug.LogError("Plant state not found");
            }
        }
    
        private int CheckingPlantState(PlantState plantState)
        {
            for (int i = 0; i < plantInfos.Count; i++)
            {
                if (plantInfos[i].plantState == plantState)
                {
                    return i;
                }
            }

            return -1;
        }

        // private void OnEnable()
        // {
        //     // foreach (var plantInfo in plantInfos)
        //     // {
        //     //     plantInfo.plantState.stateEnteredEvent.AddListener();                                                                                                                             
        //     //     plantInfo.plantState.stateLeavedEvent.AddListener();
        //     //     plantInfo.plantLifeState.stateEnteredEvent.AddListener();
        //     //     plantInfo.plantLifeState.stateLeavedEvent.AddListener();
        //     //      
        //     // }
        // }

        //  void OnDisable()
        // {
        //     // foreach (var plantInfo in plantInfos)
        //     // {
        //     //     plantInfo.plantState.stateLeavedEvent.AddListener();
        //     //     plantInfo.plantLifeState.stateLeavedEvent.AddListener();
        //     // }
        // }

    }
}