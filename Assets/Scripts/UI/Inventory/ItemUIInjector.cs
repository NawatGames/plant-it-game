using Database;
using Database.Contents;
using Database.ItemCategories;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Inventory
{
    public class ItemUIInjector : MonoBehaviour
    {
        [SerializeField] private GameObject injectorsHolder;
        [SerializeField] private RawImage itemImage;
        [SerializeField] private RawImage itemFrame;
        [SerializeField] private TMP_Text label;
        [SerializeField] private TMP_Text itemAmount;
        public void Inject(string itemName, int amount)
        {
            Item item = DatabaseSingleton.Instance.itemIntrepeter.GetItem(itemName);
            if(item == null)
            {
                Debug.LogError("Item not found");
                return;
            }
            itemImage.texture = item.itemTexture;
            //itemFrame.texture = item.itemFrame;
            label.text = item.itemName;
            itemAmount.text = amount.ToString();
            string categoryName = item.category.ToString();
            GameObject injector = injectorsHolder.transform.Find(categoryName).gameObject;
            injector.GetComponent<CategoryInjector>().Inject(itemName);
        }
    }
}