using Tile.Inventory;
using UnityEngine;

namespace TestingEvents
{
    public class SucessItemUseEvent : MonoBehaviour
    {
   
        [SerializeField] private TileItemUser tileItemUser;

        private void OnEnable()
        {
            tileItemUser.itemUseSuccess.AddListener(OnItemUseSuccess);
        }

        private void OnDisable()
        {
            tileItemUser.itemUseSuccess.RemoveListener(OnItemUseSuccess);
        }
    
        private void OnItemUseSuccess()
        {
            Debug.Log("Item use success");
        }
    }
}
