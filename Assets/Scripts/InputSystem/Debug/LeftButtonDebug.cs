using UnityEngine;

namespace InputSystem.Debug
{
    public class LeftButtonDebug : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;

        private void OnEnable()
        {
            inputManager.leftButtonChangedEvent.AddListener(OnLeftButtonChanged);
        }

        private void OnDisable()
        {
            inputManager.leftButtonChangedEvent.RemoveListener(OnLeftButtonChanged);
        }

        private void OnLeftButtonChanged(bool pressDown)
        {
            print($"Left button click: {pressDown}");
        }
    }
}