using UI.PopUp;
using UnityEngine;
using UnityEngine.Serialization;

public class SelectionController : MonoBehaviour
{
    [SerializeField] private GameObject selectionSprite;
    [SerializeField] private TileSelectionHandler tileSelectionHandler;

    private void OnEnable()
    {
        tileSelectionHandler.selectedEvent.AddListener(OnSelected);
        tileSelectionHandler.unselectedEvent.AddListener(OnUnselected);
    }

    private void OnDisable()
    {
        tileSelectionHandler.selectedEvent.RemoveListener(OnSelected);
        tileSelectionHandler.unselectedEvent.RemoveListener(OnUnselected);
    }

    public void OnSelected()
    {
        selectionSprite.SetActive(true);
    }

    public void OnUnselected()
    {
        selectionSprite.SetActive(false);
    }
}
