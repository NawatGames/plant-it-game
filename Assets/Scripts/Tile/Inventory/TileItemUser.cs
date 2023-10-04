using Handler;
using InventorySystem;
using UnityEngine;
using UnityEngine.Events;

namespace Tile.Inventory
{
    /// <summary>
    /// Habita o tile
    /// Aciona a função do item profile para intergir com o tile
    /// </summary>
    public class TileItemUser : MonoBehaviour
    {
        [SerializeField] private InventoryTileClicker tileClicker;
        [SerializeField] private TileHandler tileHandler;
        private ItemSelectionManager _selectionManager;
        public UnityEvent itemUseSuccess;
        public UnityEvent itemUseFail;
        private void Awake()
        {
            _selectionManager = GameObject.FindFirstObjectByType<ItemSelectionManager>();
        }
        private void OnEnable()
        {
            tileClicker.tileClickedEvent.AddListener(OnTileClicked);
        }
        private void OnDisable()
        {
            tileClicker.tileClickedEvent.RemoveListener(OnTileClicked);
        }

        private void OnTileClicked()
        {
            ItemProfileSO profile = _selectionManager.GetState();
            if (profile.CanInteractWith(tileHandler))
            {
                profile.InteractWith(tileHandler);
                itemUseSuccess.Invoke();
            }
            else
            {
                itemUseFail.Invoke();
            }
        }
    }
}