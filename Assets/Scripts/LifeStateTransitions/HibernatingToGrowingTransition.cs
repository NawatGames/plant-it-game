using UnityEngine;

namespace LifeStateTransitions
{
    public class HibernatingToGrowingTransition : LifeStateTransition
    {
        [SerializeField] PlantStat sleepinessMeter;
        
        protected override void OnStateEntered()
        {
            sleepinessMeter.amountChangedEvent.AddListener(OnSleepinessMeterAmountChanged);
        }
        
        protected override void OnStateLeft()
        {
            sleepinessMeter.amountChangedEvent.RemoveListener(OnSleepinessMeterAmountChanged);
        }
        
        private void OnSleepinessMeterAmountChanged(float amount)
        {
            // Returns if sleepiness meter is above treshold
            if (sleepinessMeter.AboveTreshold()) return;
            // If sleepiness is below treshold, change state to growing
            lifeStateMachine.ChangeState(growing);
        }
    }
}