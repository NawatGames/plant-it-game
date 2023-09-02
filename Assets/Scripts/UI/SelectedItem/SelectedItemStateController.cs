using UnityEngine;
using UnityEngine.UI;

public class SelectedItemStateController : MonoBehaviour
{
    [SerializeField]private SelectedItemStateMachine selectedItemStateMachine;
    [SerializeField]private GameObject inventoryItems;
    
    private void OnEnable()
    {
        foreach (Transform item in inventoryItems.transform)
        {
            item.GetComponent<Button>().onClick.AddListener(() => OnCond(item.GetSiblingIndex()));
        }
    }

    private void OnDisable()
    {
        
        foreach (Transform item in inventoryItems.transform)
        {
            item.GetComponentInChildren<Button>().onClick.RemoveListener(() => OnCond(0));
        }
    }

    private void OnCond(int arg0)
    {
        if (transform.childCount == 0)
            return;
        selectedItemStateMachine.SetState(selectedItemStateMachine.transform.GetChild(arg0).GetComponent<SelectedItemState>());
    }
}
