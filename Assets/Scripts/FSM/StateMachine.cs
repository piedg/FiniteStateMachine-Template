namespace FSM
{
    using UnityEngine;

    public class StateMachine : MonoBehaviour
    {
        private State _currentState;

        private void Update()
        {
            _currentState?.Update(Time.deltaTime);
        }

        public void SwitchState(State newState)
        {
            Debug.Log($"{gameObject.name} from {_currentState?.ToString()} to {newState?.ToString()}");

            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
        }
    }
}