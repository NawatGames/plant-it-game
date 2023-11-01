using UnityEngine;
using InputSystem;

namespace UI.slabro
{
    public class InventoryPopUpCallerClickConnector : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private InventoryPopUpManager inventoryPopUpManager;

        private void OnEnable()
        {
            inputManager.leftButtonChangedEvent.AddListener(OnLeftButtonChanged);
        }

        private void OnDisable()
        {
            inputManager.leftButtonChangedEvent.RemoveListener(OnLeftButtonChanged);
        }

        private void OnLeftButtonChanged(bool pressed)
        {
            if (pressed)
            {
                inventoryPopUpManager.OpenInventoryPopUp();
            }
        }
    }
}