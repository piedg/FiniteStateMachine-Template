using System;
using Gameplay;
using Inputs;
using UnityEngine;

namespace FSM.Player
{
    public class PlayerStateMachine : StateMachine
    {
        [field: SerializeField] public InputManager InputManager { get; set; }
        [field: SerializeField] public CustomPhysics CustomPhysics { get; set; }
        [field: SerializeField] public Movement Movement { get; set; }
        
        private void Start()
        {
            // Switch to initial state
            SwitchState(new PlayerLocomotionState(this));
        }
    }
}