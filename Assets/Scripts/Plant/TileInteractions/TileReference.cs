using Handler;
using Tile;
using UnityEngine;
using UnityEngine.Events;

namespace Handler
{
    public class TileReference : MonoBehaviour
    {
        [SerializeField] private TileHandler handler;
        public UnityEvent<TileHandler> handlerUpdateEvent;

        public void SetHandler(TileHandler newHandler)
        {
            if (handlerUpdateEvent == null) return;
            handlerUpdateEvent.Invoke(newHandler);
            handler = newHandler;
        }
    }
}