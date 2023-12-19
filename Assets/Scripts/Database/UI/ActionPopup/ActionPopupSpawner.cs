using UnityEngine;

namespace Database.UI.ActionPopup
{
    public class ActionPopupSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject parent;
        
        public GameObject Spawn(GameObject prefab)
        {   
            var clone = Instantiate(prefab, parent.transform);
            clone.SetActive(false);
            //Todo: test if SetActive(false) works
            return clone;
        }
    }
}