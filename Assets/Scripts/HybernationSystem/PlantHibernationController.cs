using System;
using UnityEngine;

public class PlantHibernationController : MonoBehaviour
{
    [SerializeField] private SleepinessMeter sleepiness;
    [SerializeField] private PlantLifeStateMachine lifeStateMachine;
    [SerializeField] private PlantLifeState hibernatingState;
    [SerializeField] [Range(0f,1f)] private float maxSleepiness = .9f;

    private void OnEnable()
    {
        sleepiness.amountChangedEvent.AddListener(OnSleepinessAmountChanged);
    }

    private void OnDisable()
    {
        sleepiness.amountChangedEvent.AddListener(OnSleepinessAmountChanged);
    }

    private void OnSleepinessAmountChanged(float amount)
    {
        if (amount < maxSleepiness) return;
        lifeStateMachine.ChangeState(hibernatingState);
    }
}