using System;
using UnityEngine;

public class GrowingToHibernatingTransition : LifeStateTransition
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
        // Returns if sleepiness meter is below treshold
        if(sleepinessMeter.BelowTreshold()) return;
        lifeStateMachine.ChangeState(hibernating);
    }
}