using Plant.LifeSystem.LifeStates;
using Plant.Stats;
using UnityEngine;

namespace Plant.LifeSystem.LifeStateTransitions
{
    public class HealthDepleted : LifeStateTransition
    {
        // Transitions when health reaches 0
        // Hibernating -> Dead
        // Ripe -> Decomposed
        // Growing -> Dead
        // Dying -> Dead
        [SerializeField] private PlantStat health;
        [SerializeField] private PlantLifeState toState;
        protected override void OnStateEntered()
        {
            health.amountChangedEvent.AddListener(OnHealthAmountChanged);
        }

        protected override void OnStateLeft()
        {
            health.amountChangedEvent.RemoveListener(OnHealthAmountChanged);
        }
    
        private void OnHealthAmountChanged(float amount)
        {
            if (amount > 0) return;
            lifeStateMachine.ChangeState(toState);
        }
    }
}