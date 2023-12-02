using UnityEngine;
using UnityEngine.Events;

namespace Plant.LifeSystem.LifeStates
{
    public class PlantLifeState : MonoBehaviour
    {
        public UnityEvent stateEnteredEvent;
        public UnityEvent stateLeavedEvent;
		
        [ContextMenu("OnEnterState")]
        public virtual void EnterState(){
            stateEnteredEvent.Invoke();
        }

        [ContextMenu("OnExitState")]
        public virtual void LeaveState(){
            stateLeavedEvent.Invoke();
        }
    }
}

//State Machine, unica responsabilidade da classe é ter um unico estado atual