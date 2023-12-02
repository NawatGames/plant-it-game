using Plant.LifeSystem.LifeStates;
using Plant.NutrientSystem;
using UnityEngine;

namespace Plant.LifeSystem.LifeStateTransitions
{
    public class NutrientDepletedTransition : LifeStateTransition
    {
        // Growing -> Dying
        // Hibernating -> Dying
        [SerializeField] private PlantNutrientHandler _plantNutrientHandler;
        [SerializeField] private PlantLifeState toState;
        protected override void OnStateEntered()
        {
            _plantNutrientHandler.neededNutrientsChangedEvent.AddListener(OnNeededNutrientsChanged);
        }
        
        protected override void OnStateLeft()
        {
            _plantNutrientHandler.neededNutrientsChangedEvent.RemoveListener(OnNeededNutrientsChanged);
        }
        
        private void OnNeededNutrientsChanged(bool hasNeededNutrients)
        {
            // If hasNeededNutrients is false, the plant enters the toState state
            if (!hasNeededNutrients)
            {
                lifeStateMachine.SetState(toState);
            }
        }
    }
}