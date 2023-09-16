using System;
using UnityEngine;

public class GrowingToHibernatingTransition : LifeStateTransition
{
    [SerializeField] SleepinessMeter sleepinessMeter;
    
    protected override void OnStateEntered()
    {
        sleepinessMeter.amountChangedEvent.AddListener(OnSleepinessMeterAmountChanged);
    }

    protected override void OnStateLeaved()
    {
        sleepinessMeter.amountChangedEvent.RemoveListener(OnSleepinessMeterAmountChanged);
    }

    private void OnSleepinessMeterAmountChanged(float amount)
    {
        if (amount < 1f) return;
        lifeStateMachine.SetState(hibernating);
    }
}