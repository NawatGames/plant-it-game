using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DirtTile
{
    public class TileDirtStateMachine : MonoBehaviour
    {
        [SerializeField] private TileDirtState currentState;
        public UnityEvent<TileDirtState> currentStateChangedEvent;

        public void SetState(TileDirtState newState)
        {
            if (currentState != null)
            {
                currentState.Leave();
            }

            currentState = newState;
            if (currentState != null)
            {
                currentState.Enter();
            }

            currentStateChangedEvent.Invoke(currentState);
        }

        public TileDirtState GetState()
        {
            return currentState;
        }

        /*private void Update()
        {
            for (int i = 0; i < 5; i++)
            {
                if (Input.GetKeyDown($"{i}"))
                {
                    SetState(transform.GetChild(i).GetComponent<TileDirtState>());
                }
            }
        }*/
    }
}