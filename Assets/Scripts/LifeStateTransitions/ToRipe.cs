using UnityEngine;

namespace LifeStateTransitions
{
    public class ToRipe : LifeStateTransition
    {
        [SerializeField] private PlantGrowingState lastGrowingState;

        protected override void OnStateEntered()
        {
            lastGrowingState.stateEnteredEvent.AddListener(OnLastStateEnter);
        }

        protected override void OnStateLeft()
        {
            lastGrowingState.stateEnteredEvent.RemoveListener(OnLastStateEnter);
        }

        private void OnLastStateEnter()
        {
            lifeStateMachine.ChangeState(ripe);
        }
    }
}