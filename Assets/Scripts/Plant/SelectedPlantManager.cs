using Interacts;
using UnityEngine;
using UnityEngine.Events;

namespace Plant
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