using System.Collections;
using System.Collections.Generic;
using Handler;
using Interacts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace GrowSystem.PlantInteracts
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