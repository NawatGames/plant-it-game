using UnityEngine;

namespace Database.ItemCategories
{
    public abstract class CategoryInjector : MonoBehaviour
    {
        public abstract void Inject(string itemName);
    }
}