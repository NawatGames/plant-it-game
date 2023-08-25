using System;
using UnityEngine;

public class PlantHibernationController : MonoBehaviour
{
    [SerializeField] private SleepinessMeter sleepiness;
    [SerializeField] private HibernationStateMachine hibernationStateMachine;
    [SerializeField] [Range(0f,1f)] float maxSleepiness = .9f;
    [SerializeField] private GameObject hibernationAnimation;
    [SerializeField] private HibernationState hibernatingState;
    [SerializeField] private HibernationState awakeState;

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
        if (ammount > maxSleepiness)
        {
            hibernationAnimation.SetActive(true);
            hibernationStateMachine.SetState(hibernatingState);
        }
        else
        {
            hibernationAnimation.SetActive(false);
            hibernationStateMachine.SetState(awakeState);
        }
    }
}