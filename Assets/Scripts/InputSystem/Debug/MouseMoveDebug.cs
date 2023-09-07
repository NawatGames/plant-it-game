using UnityEngine;

namespace InputSystem.Debug
{
    public class MouseMoveDebug : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;

        private void OnEnable()
        {
            inputManager.mouseMovementEvent.AddListener(OnMouseMovement);
        }

        private void OnDisable()
        {
            inputManager.mouseMovementEvent.RemoveListener(OnMouseMovement);
        }

        private void OnMouseMovement(Vector2 position)
        {
            print($"Mouse moved: {position}");
        }
    }
}