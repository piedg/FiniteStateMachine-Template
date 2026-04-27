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
        
        public PlayerLocomotionState LocomotionState { get; set; }
        public PlayerFallingState FallingState { get; set; }
        public PlayerJumpState JumpState { get; set; }
        
        private void Start()
        {
            LocomotionState = new PlayerLocomotionState(this);
            FallingState = new PlayerFallingState(this);
            JumpState = new PlayerJumpState(this);
            
            // Switch to initial state
            SwitchState(LocomotionState);
        }
    }
}