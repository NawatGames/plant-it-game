using UnityEngine;
using UnityEngine.Events;

public class InventoryUiSelectionManager : MonoBehaviour
{
    public UnityEvent<InventoryUIItem> selectItemEvent;
    
    public void SelectItem(InventoryUIItem item)
    {
        selectItemEvent.Invoke(item);
    }
}