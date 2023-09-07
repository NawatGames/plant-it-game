using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ChangingSpriteTesting
{
    [Serializable]
    public class PlantInfo
    {
        public PlantGrowingState plantGrowingState;
        public Sprite sprite;
    }

    public class PlantStateSpriteUpdater : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private PlantLifeState plantLifeState;
        [SerializeField] private PlantLifeStateMachine plantLifeStateMachine;
        [SerializeField] private PlantGrowingStateMachine plantGrowingStateMachine;
        [SerializeField] private List<PlantInfo> plantInfosList;
        
        Dictionary<PlantGrowingState, Sprite> plantInfosDictionary = new Dictionary<PlantGrowingState, Sprite>();
        private PlantGrowingState plantGrowingState;
        private bool isActive;
        private void Awake()
        {
            foreach (var plantInfo in plantInfosList)
            {
                plantInfosDictionary.Add(plantInfo.plantGrowingState, plantInfo.sprite);
            }
        }

        private void OnEnable()
        {
            plantLifeState.stateEnteredEvent.AddListener(OnLifeStateEntered);
            plantLifeState.stateLeavedEvent.AddListener(OnLifeStateLeaved);
            plantGrowingStateMachine.stateChangedEvent.AddListener(OnGrowingStateChanged);
            
        }

        private void OnDisable()
        {
            plantLifeState.stateEnteredEvent.RemoveListener(OnLifeStateEntered);
            plantLifeState.stateLeavedEvent.RemoveListener(OnLifeStateLeaved);
            plantGrowingStateMachine.stateChangedEvent.RemoveListener(OnGrowingStateChanged);
        }

        private void OnGrowingStateChanged(PlantGrowingState newState, PlantGrowingState oldState)
        {  
            plantGrowingState = newState;
            if (isActive)
            {
                Refresh();
            }
        }

        private void Refresh()
        {
            if(plantInfosDictionary.ContainsKey(plantGrowingState) == false) return;
            var sprite = plantInfosDictionary[plantGrowingState];
            spriteRenderer.sprite = sprite;
        }

        private void OnLifeStateEntered()
        {
            Refresh();
            isActive = true;
        }

        private void OnLifeStateLeaved()
        {
            isActive = false;
        }
    }
}