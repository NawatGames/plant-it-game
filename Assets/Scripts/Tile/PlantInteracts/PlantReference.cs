using Handler;
using Plant;
using UnityEngine;
using UnityEngine.Events;

namespace Tile.PlantInteracts
{

    public class PlantReference : MonoBehaviour
    {
        [SerializeField]private PlantHandler handler;
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
    