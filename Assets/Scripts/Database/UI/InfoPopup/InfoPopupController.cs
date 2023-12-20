using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Database.UI.InfoPopup
{
    public class InfoPopupController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler

    {
    public UnityEvent infoOpenPopupEvent;
    public UnityEvent infoClosePopupEvent;
    public UnityEvent mouseNotMovingEvent;
    public UnityEvent mouseMovingEvent;
    

    private Vector2 _mousePosition;
    private bool _mouseMoving;
    private bool _openInfoPopup;
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseMovingEvent.AddListener(OnMouseMoving);
        mouseNotMovingEvent.AddListener(OnMouseNotMoving);


    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseMovingEvent.RemoveListener(OnMouseMoving);
        mouseNotMovingEvent.RemoveListener(OnMouseNotMoving);
        StopAllCoroutines();
        if (_openInfoPopup)
        {
            infoClosePopupEvent.Invoke();
            Debug.Log("ClosePopup");
            _openInfoPopup = false;
        }
        
    }

    private void OnMouseMoving()
    {
        StopAllCoroutines();
        if (_openInfoPopup)
        {
            infoClosePopupEvent.Invoke();
            Debug.Log("ClosePopup");
            _openInfoPopup = false;
        }
        
    }

    private void OnMouseNotMoving()
    {
        StartCoroutine(MouseNotMovingCoroutine());
    }

    private IEnumerator MouseNotMovingCoroutine()
    {
        yield return new WaitForSeconds(1f);
        infoOpenPopupEvent.Invoke();
        Debug.Log("OpenPopup");
        _openInfoPopup = true;
    }

    private void Update()
    {
        var mousePosition = (Vector2)Input.mousePosition;
        if (mousePosition == _mousePosition)
        {
            if (_mouseMoving)
            {
                _mouseMoving = false;
                mouseNotMovingEvent.Invoke();
            }
        }
        else
        {
            if (!_mouseMoving)
            {
                _mouseMoving = true;
                mouseMovingEvent.Invoke();
            }
        }

        _mousePosition = mousePosition;
    }

    };


}