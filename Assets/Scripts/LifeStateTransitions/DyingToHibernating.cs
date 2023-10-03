using System.Runtime.CompilerServices;
using UnityEngine;

namespace LifeStateTransitions
{
    public class DyingToHibernating : NutrientDependantTransition
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

            if (!allNutrientsAboveMinAmount) return; // Checks if can exit dying state
            if (sleepinessStat.BelowTreshold()) return; // Checks if can enter hibernating state
            lifeStateMachine.ChangeState(hibernating);
        }
    }
}