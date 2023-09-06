using System;
using UnityEngine;

public class PlantHibernationController : MonoBehaviour
{
    [SerializeField] private SleepinessMeter sleepiness;
    [SerializeField] private PlantLifeStateMachine lifeStateMachine;
    [SerializeField] private PlantLifeState hibernatingState;
    [SerializeField] [Range(0f,1f)] float maxSleepiness = .9f;

    private void OnEnable()
    {
        sleepiness.AmmountChangedEvent.AddListener(OnSleepinessAmmountChanged);
    }

    private void OnDisable()
    {
        sleepiness.AmmountChangedEvent.AddListener(OnSleepinessAmmountChanged);
    }

    private void OnSleepinessAmmountChanged(float ammount)
    {
        if (ammount < maxSleepiness) return;
        lifeStateMachine.ChangeState(hibernatingState);
    }
}