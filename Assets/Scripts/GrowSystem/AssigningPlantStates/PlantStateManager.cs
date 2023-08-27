using UnityEngine;

namespace GrowSystem.AssigningPlantStates
{
    public class PlantStateManager : MonoBehaviour
    {
        PlantBaseState currentState;

        PlantGrowingState plantGrowingState = new PlantGrowingState();
        PlantDeadState plantDeadState = new PlantDeadState();
        PlantMatureState plantMatureState = new PlantMatureState();
        
       
        void Start()
        {
            currentState = plantGrowingState;
            
            currentState.EnterState(this);
        }

        // Update is called once per frame
        void Update()
        {
            currentState.UpdateState(this);
            
        }
    }
}
