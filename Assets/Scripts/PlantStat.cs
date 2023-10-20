using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlantStat : MonoBehaviour
{
    
    [SerializeField] [Range(0f, 1f)] private float currentAmount = 0f;
    public UnityEvent<float> amountChangedEvent;
    [SerializeField] private float threshold = 0.5f;
    
    public void SetAmount(float amount)
    {
        currentAmount = Mathf.Clamp01(amount);
        amountChangedEvent.Invoke(currentAmount);
    }
    
    public float GetAmount()
    {
        return currentAmount;
    }

    public bool AboveThreshold()
    {
        return currentAmount >= threshold;
    }
    
    public bool BelowThreshold()
    {
        return currentAmount < threshold;
    }
    
    [ContextMenu("Refresh")]
    private void Refresh()
    {
        amountChangedEvent.Invoke(currentAmount);
    }
}