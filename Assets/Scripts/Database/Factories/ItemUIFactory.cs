using Database.Contents;
using Database.Interpreters;
using UI.Inventory;
using UnityEngine;

namespace Factories
{
    public class ItemUIFactory : MonoBehaviour
    {
        [SerializeField] private GameObject _itemUIPrefab;
        GameObject CreateItemUI(string key, int amount)
        {
            GameObject itemUI = Instantiate(_itemUIPrefab);
            itemUI.GetComponent<ItemSlotUI>().Inject(key, amount);
            return itemUI;
        }
    }
}