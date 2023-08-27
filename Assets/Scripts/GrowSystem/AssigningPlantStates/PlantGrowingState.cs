using UnityEngine;

namespace GrowSystem.AssigningPlantStates
{
    public class PlantGrowingState : PlantBaseState
    {
        public Sprite plant1; 
        public Sprite plant2;   

        [SerializeField]
        private float growTime;

        public override void EnterState(PlantStateManager plant)
        {
            Debug.Log("growing");
        }

        public override void UpdateState(PlantStateManager plant)
        {
            
        }
    }
}
