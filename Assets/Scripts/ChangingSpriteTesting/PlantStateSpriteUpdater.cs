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
            plantGrowingStateMachine.StateChangedEvent.AddListener(OnGrowingStateChanged);
        }

        private void OnDisable()
        {
            plantLifeState.stateEnteredEvent.RemoveListener(OnLifeStateEntered);
            plantGrowingStateMachine.StateChangedEvent.RemoveListener(OnGrowingStateChanged);
        }

        private void OnGrowingStateChanged(PlantGrowingState arg0, PlantGrowingState plantGrowingState)
        {
            _plantGrowingState = arg0;
        }

        private void OnLifeStateEntered()
        {
            var sprite = plantInfosDictionary[_plantGrowingState];
            renderer.sprite = sprite;
        }
    }
}