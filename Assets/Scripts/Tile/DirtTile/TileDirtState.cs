﻿using UnityEngine;
using UnityEngine.Events;

namespace DirtTile
{
    public class TileDirtState : MonoBehaviour
    {
        public UnityEvent StateEnterEvent;
        public UnityEvent StateExitEvent;

        [ContextMenu("OnEnterState")]
        public virtual void EnterState()
        {
            StateEnterEvent.Invoke();
        }

        [ContextMenu("OnExitState")]
        public virtual void ExitState()
        {
            StateExitEvent.Invoke();
        }
    }
}