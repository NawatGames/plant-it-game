using UnityEngine;

namespace InputSystem.Debug
{
    public class MiddleButtonDebug : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;

        private void OnEnable()
        {
            inputManager.middleButtonChangedEvent.AddListener(OnMiddleButtonChanged);
        }

        private void OnDisable()
        {
            inputManager.middleButtonChangedEvent.RemoveListener(OnMiddleButtonChanged);
        }

        private void OnMiddleButtonChanged(bool pressDown)
        {
            print($"Middle button click: {pressDown}");
        }
    }
}