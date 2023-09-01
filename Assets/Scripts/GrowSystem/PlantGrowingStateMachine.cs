using System;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlantGrowingStateMachine : MonoBehaviour
{
    
     
     [SerializeField] private PlantGrowingState currentGrowingState;
     [SerializeField] private PlantGrowingState initialState;
     [SerializeField]private PlantGrowingState nextState;

     public UnityEvent<PlantGrowingState,PlantGrowingState> StateChangedEvent;

     private void Start(){
         if(initialState != null){
             ChangeState(initialState);
         }
     }

     public void ChangeState(PlantGrowingState newState)
     {
         var oldState = currentGrowingState;

         if (currentGrowingState != null)
         {
             currentGrowingState.LeaveState();
         }
				
         currentGrowingState = newState;

         if (currentGrowingState != null)
         {
             currentGrowingState.EnterState();
         }

         StateChangedEvent.Invoke(newState,oldState);
     }


     [ContextMenu("SetNextState")]
     private void SetNextState(){
         ChangeState(nextState);
     }
}




    

