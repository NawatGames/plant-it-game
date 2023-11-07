using Plant.Stats;
using UnityEngine;

namespace Plant.LifeSystem.LifeStateTransitions
{
    public class GrowingToHibernating : LifeStateTransition
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
            if (sleepinessMeter.AboveThreshold())
            {
                lifeStateMachine.ChangeState(hibernating);
            }
        }
    }
}