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
        
        private void Awake()
        {
            OnPlantStateChanged(plantStateMachine.GetState());
            OnPlantLifeStateChanged(plantLifeStateMachine.GetState());
        }
        private void OnEnable()
        {
            //plantStateMachine.StateChangedEvent.AddListener(OnPlantStateChanged);
            //plantLifeStateMachine.StateChangedEvent.AddListener(OnPlantLifeStateChanged);
            
        }

        private void OnDisable()
        {
            //plantStateMachine.StateChangedEvent.RemoveListener(OnPlantStateChanged);
            //plantLifeStateMachine.StateChangedEvent.RemoveListener(OnPlantLifeStateChanged);
        }

        private void OnPlantStateChanged(PlantState currentState)
        {
            int foundState = CheckingPlantState(currentState);
            int foundLifeState = CheckingPlantLifeState(plantLifeStateMachine.GetState());

            if (foundState != -1 && foundLifeState != -1)
            {
                plantInfos[foundState].spriteUpdater.UpdateSprite();
            }
            else
            {
                Debug.LogError("Plant state not found");
            }
        }

        private void OnPlantLifeStateChanged(PlantLifeState currentState)
        {
            int foundState = CheckingPlantState(plantStateMachine.GetState());
            int foundLifeState = CheckingPlantLifeState(currentState);

            if (foundState != -1 && foundLifeState != -1)
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

        private int CheckingPlantLifeState(PlantLifeState plantLifeState)
        {
            for (int i = 0; i < plantInfos.Count; i++)
            {
                if (plantInfos[i].plantLifeState == plantLifeState)
                {
                    return i;
                }
            }

            return -1;
        }
        // aaaaaaaaaaa to vcs n tem ideia de quantas vezes refiz esse script 
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