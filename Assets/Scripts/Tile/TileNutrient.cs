using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileNutrient : MonoBehaviour
{
    [SerializeField] [Range(0f,1f)] private float currentAmmount = 0f;

    public UnityEvent<float> AmmountChangedEvent;

    public void SetAmmount(float ammount)
    {
        currentAmmount = Mathf.Clamp01(ammount);
        AmmountChangedEvent.Invoke(currentAmmount);
    }

    public float GetAmmount()
    {
        return currentAmmount;
    }
[ContextMenu("Refresh")]
    private void Refresh()
    {
        AmmountChangedEvent.Invoke(currentAmmount);
    }

    public float speed;
    private void Update()
    {
        var deltaTime = speed * Time.deltaTime;
        SetAmmount(currentAmmount - deltaTime);
    }
}
