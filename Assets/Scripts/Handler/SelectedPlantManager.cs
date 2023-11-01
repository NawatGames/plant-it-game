﻿using Plant;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Handler
{

    public class SelectedPlantManager : MonoBehaviour
    {
        [SerializeField] private ItemProfileSO itemProfile;
        public UnityEvent<ItemProfileSO> profileUpdateEvent;

        public void SetPlant(ItemProfileSO newProfile)
        {
            if (profileUpdateEvent == null) return;
            profileUpdateEvent.Invoke(newProfile);
            itemProfile = newProfile;
        }
    }
}