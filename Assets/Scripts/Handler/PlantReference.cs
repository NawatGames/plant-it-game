using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Handler
{

    public class PlantReference : MonoBehaviour
    {
        public PlantHandler handler;
        public UnityEvent<PlantHandler> handlerUpdateEvent;

        public PlantHandler GetHandler()
        {   
            return handler;
        }

        public void SetHandler(PlantHandler newHandler)
        {   
            if (handlerUpdateEvent != null)
            {
                handlerUpdateEvent.Invoke(newHandler);
            }
            handler = newHandler;
            Debug.Log("current handler: " + handler);
        }
    }
}
    