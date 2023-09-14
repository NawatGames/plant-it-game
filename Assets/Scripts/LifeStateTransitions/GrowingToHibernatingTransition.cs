using System;
using UnityEngine;

public class GrowingToHibernatingTransition : LifeStateTransition
{
    [SerializeField] SleepinessMeter sleepinessMeter;
    [SerializeField] float maxSleepiness = .9f;
    
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
        if (amount < maxSleepiness) return;
        lifeStateMachine.SetState(hibernating);
    }
}