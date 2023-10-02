using UnityEngine;
using UnityEngine.Serialization;

namespace GrowSystem.LifeStates
{
    public class StateAnimationActivator : MonoBehaviour
    {
        [SerializeField] private PlantLifeState activationState;
        [SerializeField] private GameObject stateAnimation;

        private void OnEnable()
        {
            activationState.stateEnteredEvent.AddListener(EnableAnimation);
            activationState.stateLeavedEvent.AddListener(DisableAnimation);
        }

        private void OnDisable()
        {
            activationState.stateEnteredEvent.RemoveListener(EnableAnimation);
            activationState.stateLeavedEvent.RemoveListener(DisableAnimation);
        }

        private void EnableAnimation()
        {
            stateAnimation.SetActive(true);
        }

        private void DisableAnimation()
        {
            stateAnimation.SetActive(false);
        }
    }
}