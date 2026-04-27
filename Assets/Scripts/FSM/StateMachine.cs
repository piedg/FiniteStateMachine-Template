using TMPro;

namespace FSM
{
    using UnityEngine;

    public class StateMachine : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI currentStateText;
        private State _currentState;

        private void Update()
        {
            _currentState?.Tick(Time.deltaTime);
        }

        public void SwitchState(State newState)
        {
            string oldName = _currentState != null ? _currentState.GetType().Name : "None";
            string newName = newState != null ? newState.GetType().Name : "None";

            Debug.Log($"[FSM] {gameObject.name}: {oldName} —> {newName}");
            
            currentStateText.text = newState?.StateName;
            
            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
        }
    }
}