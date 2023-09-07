using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SleepinessMeter : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] private float currentAmount = 0f;
    public UnityEvent<float> amountChangedEvent;

    public void SetAmount(float amount)
    {
        currentAmount = Mathf.Clamp01(amount);
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
}