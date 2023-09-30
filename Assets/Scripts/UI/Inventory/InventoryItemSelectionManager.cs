using UnityEngine;

namespace UI.Inventory
{
    public class InventoryItemSelectionManager : MonoBehaviour
    {
        // Responsável por selecionar um item
        // State machine para guardar o item/ferramente selecionado
        private ItemProfileSO currentProfile;
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