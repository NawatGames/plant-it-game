using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HoverController : MonoBehaviour
{
    [SerializeField] private GameObject hoverSprite;
    [SerializeField] private TileColliderHandler tileColliderHandler;

    private void OnEnable()
    {
        tileColliderHandler.mouseEnteringEvent.AddListener(OnMouseEntering);
        tileColliderHandler.mouseExitingEvent.AddListener(OnMouseExiting);
    }

    private void OnDisable()
    {
        tileColliderHandler.mouseEnteringEvent.RemoveListener(OnMouseEntering);
        tileColliderHandler.mouseExitingEvent.RemoveListener(OnMouseExiting);
    }

    public void OnMouseEntering()
    {
        hoverSprite.SetActive(true);
    }

    public void OnMouseExiting()
    {
        hoverSprite.SetActive(false);
    }
    
}
