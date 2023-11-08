using UnityEngine;
using UnityEngine.Events;

namespace Plant.LifeSystem.SeasonState
{
    public class SeasonState : MonoBehaviour
    {
        public UnityEvent stateEnteredEvent;
        public UnityEvent stateLeavedEvent;

        public void EnterState()
        {
            stateEnteredEvent.Invoke();
        }


        public void LeaveState()
        {
            stateLeavedEvent.Invoke();
        }
    }
}