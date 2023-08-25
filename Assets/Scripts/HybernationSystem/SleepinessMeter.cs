using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SleepinessMeter : MonoBehaviour
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
}
