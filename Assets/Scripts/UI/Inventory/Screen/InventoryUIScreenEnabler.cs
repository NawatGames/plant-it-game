using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIScreenEnabler : MonoBehaviour
{
    [SerializeField] private InventoryUIState inventoryUIState;
    [SerializeField] private GameObject thisState;

    private void OnEnable()
    {
        inventoryUIState.inventoryUIEnterEvent.AddListener(OnEnter);
        inventoryUIState.inventoryUILeaveEvent.AddListener(OnLeave);
    }

    private void OnDisable()
    {
        inventoryUIState.inventoryUIEnterEvent.RemoveListener(OnEnter);
        inventoryUIState.inventoryUILeaveEvent.RemoveListener(OnLeave);
    }

    public void OnEnter()
    {
        thisState.SetActive(true);
    }

    public void OnLeave()
    {
        thisState.SetActive(false);
    }
}
