using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PopUp : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    private Image popUpImage;
    private Image plantImagePopUp;
    private Text plantNamePopUp;
    private Text plantStatePopUp;
    private Text dirtNutrientPopUp;
    
    public UnityEvent mouseExitEvent;
    public UnityEvent mouseEnterEvent;
    public UnityEvent destroyPopUpEvent;
    public UnityEvent<float> currentTimeChangedEvent;
    public float timeToDestroy;

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseExitEvent.Invoke();
        StartCoroutine(KillPopUpCoroutine());
    }

    private IEnumerator KillPopUpCoroutine()
    {
        var time = 0f;
        while (time < timeToDestroy)
        {
            time += Time.deltaTime;
            currentTimeChangedEvent.Invoke(time / timeToDestroy);
            yield return null;
        }

        destroyPopUpEvent.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseEnterEvent.Invoke();
        StopAllCoroutines();
        currentTimeChangedEvent.Invoke(0);
    }
}