using System.Runtime.CompilerServices;
using UnityEngine;

namespace LifeStateTransitions
{
    public class NutrientDepleted : NutrientDependantTransition
    {
        protected override void OnNutrientAmountChangedEvent(float amount)
        {
            if (amount >= minAmount) return; //If tile has amount of nutrient above minAmount, do nothing
            lifeStateMachine.ChangeState(dying); //If tile has amount of nutrient below minAmount, change state to dying
        }
    }
}