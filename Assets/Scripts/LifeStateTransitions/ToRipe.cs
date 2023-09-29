using UnityEngine;

namespace LifeStateTransitions
{
    public class ToRipe : LifeStateTransition
    {
        [SerializeField] private PlantGrowingState lastGrowingState;

        protected override void OnStateEntered()
        {
            lastGrowingState.stateEnterEvent.AddListener(OnLastStateEnter);
        }

        protected override void OnStateLeft()
        {
            lastGrowingState.stateEnterEvent.RemoveListener(OnLastStateEnter);
        }

        private void OnLastStateEnter()
        {
            lifeStateMachine.ChangeState(ripe);
        }
    }
}