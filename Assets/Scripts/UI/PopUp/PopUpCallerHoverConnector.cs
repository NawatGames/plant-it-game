using System.Collections;
using InputSystem;
using UnityEngine;
using UnityEngine.Serialization;

public class PopUpCallerHoverConnector : MonoBehaviour
{
    public float idleTimeLimit = 0.5f;
    
    [SerializeField] private InputManager inputManager;
    [SerializeField] private TileSelectionManager tileSelectionManager;

    private void OnEnable()
    {
        inputManager.mouseDeltaStoppedEvent.AddListener(OnMouseDeltaStopped);
        inputManager.mouseDeltaMovedEvent.AddListener(OnMouseDeltaMoved);
    }

    private void OnDisable()
    {
        inputManager.mouseDeltaStoppedEvent.RemoveListener(OnMouseDeltaStopped);
        inputManager.mouseDeltaMovedEvent.RemoveListener(OnMouseDeltaMoved);
    }
    
    public IEnumerator OpenPopUpCoroutine()
    {
        yield return new WaitForSeconds(idleTimeLimit);
        tileSelectionManager.OpenPopUp();
    }
    
    private void OnMouseDeltaStopped(Vector2 arg0)
    {
        StartCoroutine(OpenPopUpCoroutine());
    }

    private void OnMouseDeltaMoved(Vector2 arg0)
    {
        StopAllCoroutines();
    }
}