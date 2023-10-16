using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Handler
{

    public class PlantReference : MonoBehaviour
    {
        [SerializeField] private PlantHandler handler;
        public UnityEvent<PlantHandler> handlerUpdateEvent;

        public void SetHandler(PlantHandler newHandler)
        {
            if (handlerUpdateEvent == null) return;
            handlerUpdateEvent.Invoke(newHandler);
            handler = newHandler;
        }
    }
}
    