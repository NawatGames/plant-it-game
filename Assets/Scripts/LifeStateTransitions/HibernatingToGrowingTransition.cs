using UnityEngine;

namespace LifeStateTransitions
{
    public class HibernatingToGrowingTransition : LifeStateTransition
    {
        [SerializeField] SleepinessMeter sleepinessMeter;
        
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
            if (amount > 0) return;
            lifeStateMachine.SetState(growing);
        }
    }
}