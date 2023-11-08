using Plant.NutrientSystem;
using Plant.Stats;
using UnityEngine;

namespace Plant.LifeSystem.LifeStateTransitions
{
    public class DyingToHibernating : LifeStateTransition
    {
        [SerializeField] private PlantStat _sleepinessMeter;
        [SerializeField] private PlantNutrientHandler _nutrientHandler;

        protected override void OnStateEntered()
        {
            _nutrientHandler.neededNutrientsChangedEvent.AddListener(OnNeededNutrientsChanged);
        }

        protected override void OnStateLeft()
        {
            _nutrientHandler.neededNutrientsChangedEvent.RemoveListener(OnNeededNutrientsChanged);
        }

        private void OnNeededNutrientsChanged(bool hasNeededNutrients)
        {
            // If plant has needed nutrients and sleepinessMeter is above treshold,
            // the plant enters the hibernating state
            if (_sleepinessMeter.AboveThreshold() && hasNeededNutrients)
            {
                lifeStateMachine.SetState(hibernating);
            }
        }
    }
}