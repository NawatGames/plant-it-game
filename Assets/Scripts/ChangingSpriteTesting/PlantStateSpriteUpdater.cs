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
        [SerializeField] private SpriteRenderer renderer;
        [SerializeField] private PlantLifeState plantLifeState;
        [SerializeField] private PlantLifeStateMachine plantLifeStateMachine;
        [SerializeField] private PlantGrowingStateMachine plantGrowingStateMachine;
        [SerializeField] private List<PlantInfo> plantInfosList;
        
        Dictionary<PlantGrowingState, Sprite> plantInfosDictionary = new Dictionary<PlantGrowingState, Sprite>();
        private PlantGrowingState _plantGrowingState;
        private bool _isActive;
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
            plantGrowingStateMachine.StateChangedEvent.AddListener(OnGrowingStateChanged);
            
        }

        private void OnDisable()
        {
            plantLifeState.stateEnteredEvent.RemoveListener(OnLifeStateEntered);
            plantLifeState.stateLeavedEvent.RemoveListener(OnLifeStateLeaved);
            plantGrowingStateMachine.StateChangedEvent.RemoveListener(OnGrowingStateChanged);
        }

        private void OnGrowingStateChanged(PlantGrowingState newState, PlantGrowingState oldState)
        {  
            _plantGrowingState = newState;
            if (_isActive)
            {
                Refresh();
            }
        }

        private void Refresh()
        {
            if(plantInfosDictionary.ContainsKey(_plantGrowingState) == false) return;
            var sprite = plantInfosDictionary[_plantGrowingState];
            renderer.sprite = sprite;
        }

        private void OnLifeStateEntered()
        {
            Refresh();
            _isActive = true;
        }

        private void OnLifeStateLeaved()
        {
            _isActive = false;
        }
    }
}