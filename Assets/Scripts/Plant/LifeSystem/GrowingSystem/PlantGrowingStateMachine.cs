using KevinCastejon.MoreAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace Plant.LifeSystem.GrowingSystem
{
    public class PlantGrowingStateMachine : MonoBehaviour
    {
        [SerializeField][ReadOnly] private PlantGrowingState currentGrowingState;
        [SerializeField][ReadOnlyOnPlay] private PlantGrowingState initialState;
        [SerializeField] private PlantGrowingState nextState;

        public UnityEvent<PlantGrowingState, PlantGrowingState> stateChangedEvent;

        private void Start()
        {
            if (initialState != null)
            {
                ChangeState(initialState);
            }
        }

        public void ChangeState(PlantGrowingState newState)
        {
            var oldState = currentGrowingState;

            if (currentGrowingState != null)
            {
                currentGrowingState.ExitState();
            }

            currentGrowingState = newState;

            if (currentGrowingState != null)
            {
                currentGrowingState.EnterState();
            }

            stateChangedEvent.Invoke(newState, oldState);
        }
        public PlantGrowingState GetState()
        {
            return currentGrowingState;
        }
    
        public enum PlantGrowingStateKey
        {
            State1,
            State2,
            State3

        }
    
        public T LocateLifeState<T>(PlantGrowingStateKey key)
        {
            Debug.Log(key.ToString());
            return transform.Find(key.ToString()).GetComponent<T>();
        }
    
        public void Set1NextState(PlantGrowingState newState)
        {
            nextState = newState;
        }
   
        [ContextMenu("SetNextState")]
        private void SetNextState()
        {
            ChangeState(nextState);
        }
    }
}