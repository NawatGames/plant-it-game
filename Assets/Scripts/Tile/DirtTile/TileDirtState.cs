using UnityEngine;
using UnityEngine.Events;

namespace DirtTile
{
    public class TileDirtState : MonoBehaviour
    {
        public UnityEvent enterEvent;
        public UnityEvent leaveEvent;

        public virtual void Enter()
        {
            enterEvent.Invoke();
        }

        public virtual void Leave()
        {
            leaveEvent.Invoke();
        }
    }
}