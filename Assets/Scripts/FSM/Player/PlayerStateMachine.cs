using System;
using UnityEngine;

namespace FSM.Player
{
    public class PlayerStateMachine : StateMachine
    {
        private void Start()
        {
            // Switch to initial state
            SwitchState(new PlayerLocomotionState(this));
        }
    }
}