using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIStateButtonTransition : MonoBehaviour
{
    public InventoryUIStateMachine inventoryUIStateMachine;
    public InventoryUIState nextState;
    
    [SerializeField] private Button button;

    private void OnEnable()
    {
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        inventoryUIStateMachine.SetState(nextState);
    }
}