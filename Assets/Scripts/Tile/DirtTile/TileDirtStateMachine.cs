using System;
using System.Collections;
using System.Collections.Generic;
using KevinCastejon.MoreAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.WSA;

namespace DirtTile
{
    public class TileDirtStateMachine : MonoBehaviour
    {
        [SerializeField][ReadOnly] private TileDirtState currentState;
        [SerializeField][ReadOnlyOnPlay] private TileDirtState initialState;
        [SerializeField] private TileDirtState nextState;
        public UnityEvent<TileDirtState, TileDirtState> currentStateChangedEvent;
        
        public void Start()
        {
            if (initialState != null)
            {
                SetState(initialState);
            }
        }
        public void SetState(TileDirtState newState)
        {   
            var oldState = currentState;
            
            if (currentState != null)
            {
                currentState.ExitState();
            }

            currentState = newState;
            
            if (currentState != null)
            {
                currentState.EnterState();
            }

            currentStateChangedEvent.Invoke(newState, oldState);
        }

        public TileDirtState GetState()
        {
            return currentState;
        }
        
        [ContextMenu("SetNextState")]
        private void SetNextState(){
            SetState(nextState);
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