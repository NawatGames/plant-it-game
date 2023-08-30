using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class ScreenActivator : MonoBehaviour
{
    [SerializeField] private GameObject screenToActivate;
    [SerializeField] private ScreenState screenState;

    private void OnEnable()
    {
        screenState.stateEnteredEvent.AddListener(OnStateEntered);
        screenState.stateLeavedEvent.AddListener(OnStateLeaved);
    }

    private void OnDisable()
    {
        screenState.stateEnteredEvent.RemoveListener(OnStateEntered);
        screenState.stateLeavedEvent.RemoveListener(OnStateLeaved);
    }
    
    protected virtual void OnStateEntered()
    {
        screenToActivate.SetActive(true);
    }
    
    protected virtual void OnStateLeaved()
    {
        screenToActivate.SetActive(false);
    }
}