using UnityEngine;

namespace LifeStateTransitions
{
    public class ToRipe : LifeStateTransition
    {
        [SerializeField] private PlantLifeState lastState;

        protected override void OnStateEntered()
        {
            lastState.stateEnteredEvent.AddListener(OnLastStateEnter);
        }

        protected override void OnStateLeft()
        {
            lastState.stateEnteredEvent.RemoveListener(OnLastStateEnter);
        }

        private void OnLastStateEnter()
        {
            lifeStateMachine.SetState(ripe);
        }
    }
}