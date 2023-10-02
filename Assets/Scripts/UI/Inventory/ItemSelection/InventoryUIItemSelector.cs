using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIItemSelector : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private InventoryUIItem item;

    private InventoryUiSelectionManager _inventoryUiSelectionManager;

    private void Awake()
    {
        _inventoryUiSelectionManager = FindFirstObjectByType<InventoryUiSelectionManager>();
    }

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
        _inventoryUiSelectionManager.SelectItem(item);
    }
}