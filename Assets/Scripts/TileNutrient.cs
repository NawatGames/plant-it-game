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
        currentAmmount = ammount;
        AmmountChangedEvent.Invoke(currentAmmount);
    }

    public float GetAmmount()
    {
        return currentAmmount;
    }
}
