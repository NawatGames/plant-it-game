using UnityEngine;

namespace LifeStateTransitions
{
    public class HibernatingToGrowing : LifeStateTransition
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
            // Returns if sleepiness meter is above threshold
            if (sleepinessMeter.AboveThreshold()) return;
            // If sleepiness is below threshold, change state to growing
            lifeStateMachine.ChangeState(growing);
        }
    }
}