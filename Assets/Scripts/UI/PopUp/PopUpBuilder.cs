using System;
using System.Collections;
using System.Collections.Generic;
using UI.PopUp;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = System.Numerics.Vector3;

public class PopUpBuilder : MonoBehaviour
{
    private Camera camera;

    [SerializeField] private GameObject popUpPrefab;
    [SerializeField] private Transform canvas;
    [SerializeField] private Vector2Int popUpOffset;

    private void Start()
    {
        camera = Camera.main;
    }

    public PopUp BuildPopUp(TileSelectionHandler tileSelectionHandler)
    {
        var prefab = popUpPrefab;
        if(tileSelectionHandler.popUpPrefab != null) prefab = tileSelectionHandler.popUpPrefab;
        
        GameObject instance = Instantiate(prefab, canvas);

        var position = tileSelectionHandler.transform.position;
        var screenPoint = (Vector2)camera.WorldToScreenPoint(position) + popUpOffset;

        instance.GetComponent<RectTransform>().anchoredPosition = screenPoint;
        
        var popUp = instance.GetComponent<PopUp>();
        if (popUp == null) Debug.LogError("PopUp prefab does not have PopUp component");
        return popUp;
    }
}

