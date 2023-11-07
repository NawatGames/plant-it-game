using UnityEngine;
using UnityEngine.Events;

namespace Plant.LifeSystem.SeasonState
{
    public class SeasonStateMachine : MonoBehaviour
    {
        public UnityEvent<global::Plant.LifeSystem.SeasonState.SeasonState> stateChangedEvent;
        [SerializeField] private global::Plant.LifeSystem.SeasonState.SeasonState currentState;

        public void SetState(global::Plant.LifeSystem.SeasonState.SeasonState newState)
        {
            if (currentState != null)
            {
                currentState.LeaveState();
            }

            currentState = newState;
            stateChangedEvent.Invoke(newState);
            if (currentState != null)
            {
                currentState.EnterState();
            }
        }

        public global::Plant.LifeSystem.SeasonState.SeasonState GetState()
        {
            return currentState;
        }
    }
}