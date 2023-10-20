using GrowSystem;
using UnityEngine;

namespace LifeStateTransitions
{
    public class DyingToGrowing : LifeStateTransition 
    {
        [SerializeField] PlantNutrientHandler _plantNutrientHandler;
        [SerializeField] private PlantStat _sleepinessMeter;
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
            // hasNeededNutrients and sleepinessMeter.BelowThreshold() are both true
            if(hasNeededNutrients && _sleepinessMeter.BelowThreshold())
            {
                lifeStateMachine.SetState(growing);
            }
        }
    }
}