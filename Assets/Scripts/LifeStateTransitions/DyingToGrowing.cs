using UnityEngine;

namespace LifeStateTransitions
{
    public class DyingToGrowing : NutrientDependantTransition
    {
        [SerializeField] private PlantStat sleepinessStat;
        protected override void OnNutrientAmountChangedEvent(float amount)
        {
            bool allNutrientsAboveMinAmount = true;
            foreach(TileNutrient n in nutrients)
            {
                if(n.GetAmount() < minAmount)
                {
                    allNutrientsAboveMinAmount = false;
                    break;
                }
            }
        
            if(!allNutrientsAboveMinAmount) return; // Checks if can exit dying state
            if(sleepinessStat.AboveTreshold()) return; // Checks if can enter growing state
            lifeStateMachine.ChangeState(growing);
        }
    }
}