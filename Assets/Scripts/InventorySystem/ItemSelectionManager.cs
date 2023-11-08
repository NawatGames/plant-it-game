using Interacts;
using UnityEngine;

namespace InventorySystem
{
    public class ItemSelectionManager : MonoBehaviour
    {
        // Responsável por selecionar um item
        // State machine para guardar o item/ferramente selecionado
        [SerializeField] private ItemProfileSO currentProfile;
        public void SetState(ItemProfileSO newProfile)
        {
            if(newProfile == null) return;
            currentProfile = newProfile;
        }

        public ItemProfileSO GetState()
        {
            return currentProfile;
        }
    }
}