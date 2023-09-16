using UnityEngine;

namespace LifeStateTransitions
{
    public class GrowingToRipe : LifeStateTransition
    {
        [SerializeField] private PlantLifeState lastState;

        protected override void OnStateEntered()
        {
            base.OnStateEntered();
        }

        protected override void OnStateLeft()
        {
            
        }
    }
}