using System;
using InputSystem;
using UI.PopUp;
using UnityEngine;
using UnityEngine.Events;

public class TileSelectionManager : MonoBehaviour
{
    private Camera cameraMain;
    
    [SerializeField] private InputManager inputManager;
    private Vector2 _mousePosition;
    private TileSelectionHandler _currentTileSelectionHandler;
    public UnityEvent<TileSelectionHandler> currentTilePopUpHandlerChangedEvent;
    [SerializeField] private PopUpBuilder popUpBuilder;
    private PopUp _buildPopUp;

    private void Start()
    {
        cameraMain = Camera.main;
    }

    private void OnEnable()
    {
        inputManager.mouseMovementEvent.AddListener(OnMouseMovement);
    }

    private void OnDisable()
    {
        inputManager.mouseMovementEvent.RemoveListener(OnMouseMovement);
    }
    
    [ContextMenu("OpenPopUp")]
    public void OpenPopUp()
    {
        RaycastHit2D hit = Physics2D.Raycast(cameraMain.ScreenToWorldPoint(_mousePosition),
            Vector2.zero);
        var tilePopUpHandler = null as TileSelectionHandler;
        if (hit.collider != null)
        {
            GameObject hitObject = hit.collider.gameObject;
            tilePopUpHandler = hitObject.GetComponent<TileSelectionHandler>();
        }
        SetTilePopUpHandle(tilePopUpHandler);
    }

    private void SetTilePopUpHandle(TileSelectionHandler tileSelectionHandler)
    {
        if (tileSelectionHandler == _currentTileSelectionHandler)
        {
            return;
        }
        
        if(_currentTileSelectionHandler != null)
        {
            _currentTileSelectionHandler.Unselect();
        }

        if (_buildPopUp != null)
        {
            _buildPopUp.destroyPopUpEvent.RemoveListener(OnPopUpClosed);
            Destroy(_buildPopUp.gameObject);
        }
        _currentTileSelectionHandler = tileSelectionHandler;
        if(_currentTileSelectionHandler != null)
        {
            _currentTileSelectionHandler.Select();
        }
        currentTilePopUpHandlerChangedEvent.Invoke(tileSelectionHandler);
        if (tileSelectionHandler == null)
        {
            
            return;
        }
        _buildPopUp = popUpBuilder.BuildPopUp(tileSelectionHandler);
        _buildPopUp.destroyPopUpEvent.AddListener(OnPopUpClosed);
    }

    public void OnPopUpClosed()
    {
        SetTilePopUpHandle(null);
    }
    
    private void OnMouseMovement(Vector2 arg0)
    {
        _mousePosition = arg0;
    }
    
}