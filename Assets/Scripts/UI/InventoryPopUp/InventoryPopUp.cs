using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryPopUp : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    private Image inventoryPopUpImage;

    public UnityEvent mouseExitEvent;
    public UnityEvent mouseEnterEvent;
    public UnityEvent destroyPopUpEvent;
    public float timeToDestroy;

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseExitEvent.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseEnterEvent.Invoke();
    }
}