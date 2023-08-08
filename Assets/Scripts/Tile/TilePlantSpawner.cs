using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TilePlantSpawner : MonoBehaviour
{
    [SerializeField] private TileStateMachine stateMachine;
    private void OnEnable()
    {
        stateMachine.StateChangedEvent.AddListener(StateUpdate);
    }

    private void OnDisable()
    {
        stateMachine.StateChangedEvent.RemoveListener(StateUpdate);
    }
    
    private void StateUpdate(PlantProfileSO profile)
    {
        GameObject plant = Instantiate(profile.prefab);
    }
}
