using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryPopUpManager : MonoBehaviour
{
    private InventoryPopUpHandler _currentInventoryPopUpHandler = null;
    private InventoryPopUp _buildInventoryPopUp;
    private Vector2 _mousePosition;
    [SerializeField] private GraphicRaycaster mRaycaster;
    private PointerEventData _mPointerEventData;
    public UnityEvent<InventoryPopUp> inventoryPopUpOpenedEvent;
    public UnityEvent inventoryPopUpClosedEvent;
    [SerializeField] private EventSystem m_EventSystem;
    [SerializeField] private InventoryPopUpBuilder inventoryPopUpBuilder;

    private bool hitSlot = false;
    private RaycastResult currentSlot;
    
    public void OpenInventoryPopUp()
    {
        _mPointerEventData = new PointerEventData(m_EventSystem);
        _mPointerEventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();

        mRaycaster.Raycast(_mPointerEventData, results);
        hitSlot = false;
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.CompareTag("Slot"))
            {
                hitSlot = true;
                currentSlot = result;
            }
            if (result.gameObject.GetComponentInParent<InventoryPopUp>())
            {
                return;
            }
        }
        if (hitSlot)
        {
            var inventoryPopUpHandler = currentSlot.gameObject.GetComponentInChildren<InventoryPopUpHandler>();
            SetTilePopUpHandle(inventoryPopUpHandler);
        }
        else
        {
            SetTilePopUpHandle(null);
        }
    }
    
    private void SetTilePopUpHandle(InventoryPopUpHandler inventoryPopUpHandler)
    {
        if (inventoryPopUpHandler == _currentInventoryPopUpHandler)
        {
            return;
        }
        
        if (_buildInventoryPopUp != null)
        {
            _buildInventoryPopUp.destroyPopUpEvent.RemoveListener(OnInventoryPopUpClosed);
            Destroy(_buildInventoryPopUp.gameObject);
        }
        
        if (inventoryPopUpHandler == null)
        {
            return;
        }
        
        _buildInventoryPopUp = inventoryPopUpBuilder.BuildPopUp(inventoryPopUpHandler);
        inventoryPopUpOpenedEvent.Invoke(_buildInventoryPopUp);
        _buildInventoryPopUp.destroyPopUpEvent.AddListener(OnInventoryPopUpClosed);
    }
    
    public void OnInventoryPopUpClosed()
    {
        print("InventoryPopUpClosed");
        SetTilePopUpHandle(null);
        inventoryPopUpClosedEvent.Invoke();
    }
    
}