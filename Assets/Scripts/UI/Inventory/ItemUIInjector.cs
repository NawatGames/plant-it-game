using Database.Contents;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Inventory
{
    public class ItemUIInjector : MonoBehaviour
    {
        [SerializeField] private Image itemImage;
        [SerializeField] private Image itemFrame;
        [SerializeField] private TMP_Text itemName;
        [SerializeField] private TMP_Text itemAmount;
        public void Inject(Item item, int amount)
        {
            
        }
    }
}