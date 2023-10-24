using System.Collections;
using System.Collections.Generic;
using Handler;
using Interacts;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Events;

namespace GrowSystem.PlantInteracts
{

    public class PlantSpawner : MonoBehaviour
    {
        
        [SerializeField] private TileHandler tileHandler;
        public GameObject tile;
        [SerializeField] private Vector3 position;
        public UnityEvent OnPlantSpawned;
        
        private PlantStat Health;
        private PlantStat Sleepiness;

        
        
        
        public PlantHandler SpawnPlant(GameObject plantPrefab)
        {
            Debug.Log("Iniciate SpawnPlant");
            
           
            position = transform.position;
            Debug.Log("SpawnPlant: " + position);
            GameObject plant = Instantiate(plantPrefab, position, Quaternion.identity);
            Debug.Log("SpawnPlant:Instantiate " + plant);
            PlantHandler plantHandler = plant.GetComponentInChildren<PlantHandler>();
            if(plantHandler == null) Debug.Log("PlantSpawner: PlantHandler não encontrado");
            OnPlantSpawned.Invoke();
            Debug.Log("OnPlantSpawned event invoked");
            return plantHandler;
        }

        public void InjectPlantData(PlantHandler plantHandler)
        {
            var stats = plantHandler.transform.parent.Find("Stats");
            Health = stats.transform.Find("Health").GetComponent<PlantStat>();
            Sleepiness = stats.transform.Find("Sleepiness").GetComponent<PlantStat>();
            Health.SetAmount(1f);
            Sleepiness.SetAmount(0f);
            Debug.Log("InjectPlantData: Set stats");
            
            PlantGrowingStateMachine plantGrowingStateMachine = plantHandler.growingStateMachine;
            PlantGrowingState state1 = plantGrowingStateMachine.LocateLifeState<PlantGrowingState>(PlantGrowingStateMachine.PlantGrowingStateKey.State1);
            // plantGrowingStateMachine.SetInitialState(state1);
            plantGrowingStateMachine.ChangeState(state1);
           
           
            
            Debug.Log("InjectPlantData: Set "+ plantGrowingStateMachine.GetState());
            
            
            PlantLifeStateMachine plantLifeStateMachine = plantHandler.plantLifeStateMachine;
            PlantLifeState growing = plantLifeStateMachine.LocateLifeState<PlantLifeState>(PlantLifeStateMachine.PlantLifeStateKey.Growing);
            // plantLifeStateMachine.SetInitialState(growing);
            plantLifeStateMachine.ChangeState(growing);
            plantLifeStateMachine.ChangeState(growing);
            Debug.Log("InjectPlantData: Set growing");
            
         
        }
    }
}
