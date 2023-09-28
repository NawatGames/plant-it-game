using System;
using KevinCastejon.MoreAttributes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class TileStateMachine : MonoBehaviour
{
    [SerializeField][ReadOnly] private PlantProfileSO currentProfileSo;
    public UnityEvent<PlantProfileSO> stateChangedEvent;
    [SerializeField][ReadOnlyOnPlay] private PlantProfileSO initialProfileSo;
    [SerializeField] private PlantProfileSO nextProfile;
    
    public void Start()
    {
        if (initialProfileSo != null)
        {
            SetProfile(initialProfileSo);
        }
    }
    public void SetProfile(PlantProfileSO newProfile)
    {   
        
        if (currentProfileSo != null)
        {
            currentProfileSo.plantUnselectEvent.Invoke();
        }

        currentProfileSo = newProfile;

        stateChangedEvent.Invoke(newProfile);

        if (currentProfileSo != null)
        {
            currentProfileSo.plantSelectEvent.Invoke();
        }
    }

    public PlantProfileSO GetProfile()
    {
        return currentProfileSo;
    }
    [ContextMenu("SetNextState")]
    private void SetNextState(){
        SetProfile(nextProfile);
    }
}