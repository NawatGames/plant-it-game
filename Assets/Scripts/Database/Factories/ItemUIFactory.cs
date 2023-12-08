using Database.Contents;
using Database.Interpreters;
using UI.Inventory;
using UnityEngine;

namespace Factories
{
    public class ItemUIFactory : MonoBehaviour
    {
        [SerializeField] private ItemIntrepeter _itemDb;
        [SerializeField] private GameObject _itemUIPrefab;
        GameObject CreateItemUI(string key, int amount, Transform parent)
        {
            Item item = _itemDb.GetItem(key);
            GameObject itemUI = Instantiate(_itemUIPrefab, parent);
            itemUI.GetComponent<ItemUIInjector>().Inject(item, amount);
            return itemUI;
        }
    }
}