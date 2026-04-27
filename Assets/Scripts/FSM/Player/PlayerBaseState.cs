using UnityEngine;

namespace FSM.Player
{
    public abstract class PlayerBaseState : State
    {
        protected PlayerStateMachine stateMachine;

        public PlayerBaseState(PlayerStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        protected void Jump()
        {
            if (stateMachine.CustomPhysics.IsGrounded)
            {
                stateMachine.SwitchState(new PlayerJumpState(stateMachine));
            }
        }
    }
}