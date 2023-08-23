using UnityEngine;

namespace InputSystem.Debug
{
    public class ScrollMoveDebug : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;

        private void OnEnable()
        {
            inputManager.mouseMovementEvent.AddListener(OnScrollMovement);
        }

        private void OnDisable()
        {
            inputManager.mouseMovementEvent.RemoveListener(OnScrollMovement);
        }

        private void OnScrollMovement(Vector2 position)
        {
            print($"Mouse moved: {position}");
        }
    }
}