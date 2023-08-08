using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TileStateMachine : MonoBehaviour
{
    [SerializeField] private PlantProfileSO currentProfileSO;
    public UnityEvent<PlantProfileSO> StateChangedEvent;

    public void SetProfile(PlantProfileSO newProfile)
    {
        if (currentProfileSO != null)
        {
            currentProfileSO.plantUnselectEvent.Invoke();
        }
        
        currentProfileSO = newProfile;
        
        StateChangedEvent.Invoke(newProfile);
        
        if (currentProfileSO != null)
        {
            currentProfileSO.plantSelectEvent.Invoke();
        }
    }
    
    public PlantProfileSO GetProfile()
    {
        return currentProfileSO;
    }
}