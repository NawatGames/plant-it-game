using System.Collections;
using System.Collections.Generic;
using Handler;
using Interacts;
using Unity.VisualScripting;
using UnityEngine;

namespace GrowSystem.PlantInteracts
{
    public class PlantRemover : MonoBehaviour
    {   
      
        public void RemovePlant(PlantReference plantReference)
        {
            Transform plantTransform = plantReference.GetHandler().transform.parent;
            GameObject plantObject = plantTransform.gameObject;
            Destroy(plantObject);    
        }
    }
}