using InputSystem;
using UnityEngine;
using UnityEngine.Serialization;

public class PopUpCallerClickConnector : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private TileSelectionManager tileSelectionManager;
    
    private void OnEnable()
    {
        inputManager.leftButtonChangedEvent.AddListener(OnLeftButtonChanged);
    }
    
    private void OnDisable()
    {
        inputManager.leftButtonChangedEvent.RemoveListener(OnLeftButtonChanged);
    }
    
    private void OnLeftButtonChanged(bool arg0)
    {
        if (arg0)
        {
            tileSelectionManager.OpenPopUp();
        }
    }
}