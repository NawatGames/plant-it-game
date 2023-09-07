using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileNutrient : MonoBehaviour
{
    [SerializeField] [Range(0f,1f)] private float currentAmount = 0f;

    public UnityEvent<float> amountChangedEvent;

    public void SetAmmount(float ammount)
    {
        currentAmount = Mathf.Clamp01(ammount);
        amountChangedEvent.Invoke(currentAmount);
    }

    public float GetAmount()
    {
        return currentAmount;
    }
[ContextMenu("Refresh")]
    private void Refresh()
    {
        amountChangedEvent.Invoke(currentAmount);
    }

    public float speed;
    private void Update()
    {
        var deltaTime = speed * Time.deltaTime;
        SetAmmount(currentAmount - deltaTime);
    }
}
