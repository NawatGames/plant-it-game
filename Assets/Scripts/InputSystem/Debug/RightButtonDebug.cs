using UnityEngine;

namespace InputSystem.Debug
{
    public class RightButtonDebug : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;

        private void OnEnable()
        {
            inputManager.rightButtonChangedEvent.AddListener(OnRightButtonChanged);
        }

        private void OnDisable()
        {
            inputManager.rightButtonChangedEvent.RemoveListener(OnRightButtonChanged);
        }

        private void OnRightButtonChanged(bool pressDown)
        {
            print($"Right button click: {pressDown}");
        }
    }
}