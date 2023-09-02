using UnityEngine;
using UnityEngine.Events;

public class SelectedItemStateMachine : MonoBehaviour
{
    [SerializeField] private SelectedItemState currentState;
    public UnityEvent<SelectedItemState> currentStateChangedEvent;

    public void SetState(SelectedItemState newState)
    {
        if (currentState != null)
        {
            currentState.Leave();
        }

        currentState = newState;
        if (currentState != null)
        {
            currentState.Enter();
        }

        currentStateChangedEvent.Invoke(currentState);
    }

    public SelectedItemState GetState()
    {
        return currentState;
    }
}
