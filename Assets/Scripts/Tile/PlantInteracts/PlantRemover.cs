using UnityEngine;
using UnityEngine.Events;

namespace Tile.PlantInteracts
{
    public class PlantRemover : MonoBehaviour
    {   
        public UnityEvent PlantRemovedEvent;
      
        public void RemovePlant(GameObject plantObject)
        {
            Destroy(plantObject);
            PlantRemovedEvent.Invoke();
            Debug.Log("PlantRemovedEvent invoked");
        }
       
    }
}