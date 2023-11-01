using System;
using UnityEngine;

public class StateAnimationActivator : MonoBehaviour
{
    [SerializeField] private PlantLifeState hibernationState;
    [SerializeField] private GameObject hibernationAnimation;

    private void OnEnable()
    {
        hibernationState.stateEnteredEvent.AddListener(EnableAnimation);
        hibernationState.stateLeavedEvent.AddListener(DisableAnimation);
    }

    private void OnDisable()
    {
        hibernationState.stateEnteredEvent.RemoveListener(EnableAnimation);
        hibernationState.stateLeavedEvent.RemoveListener(DisableAnimation);
    }

    private void EnableAnimation()
    {
        hibernationAnimation.SetActive(true);
    }

    private void DisableAnimation()
    {
        hibernationAnimation.SetActive(false);
    }
}