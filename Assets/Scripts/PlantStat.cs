using UnityEngine;
using UnityEngine.Events;

public class PlantStat : MonoBehaviour
{
    
    [SerializeField] [Range(0f, 1f)] private float currentAmount = 0f;
    public UnityEvent<float> amountChangedEvent;
    [SerializeField] private float treshold = 0.5f;
    
    public void SetAmount(float amount)
    {
        currentAmount = Mathf.Clamp01(amount);
        amountChangedEvent.Invoke(currentAmount);
    }
    
    public float GetAmount()
    {
        return currentAmount;
    }

    public bool AboveTreshold()
    {
        return currentAmount >= treshold;
    }
    
    public bool BelowTreshold()
    {
        return currentAmount < treshold;
    }
    
    [ContextMenu("Refresh")]
    private void Refresh()
    {
        amountChangedEvent.Invoke(currentAmount);
    }
}