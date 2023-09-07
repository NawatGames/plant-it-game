using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TileStateMachine : MonoBehaviour
{
    [SerializeField] private PlantProfileSO currentProfileSO;
    public UnityEvent<PlantProfileSO> stateChangedEvent;

    public void SetProfile(PlantProfileSO newProfile)
    {
        if (currentProfileSO != null)
        {
            currentProfileSO.plantUnselectEvent.Invoke();
        }
        
        currentProfileSO = newProfile;
        
        stateChangedEvent.Invoke(newProfile);
        
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