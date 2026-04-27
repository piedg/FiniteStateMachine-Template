using UnityEngine;

namespace FSM.Player
{
    public class PlayerFallingState : PlayerBaseState
    {
        public PlayerFallingState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
            StateName = "Falling";
        }

        public override void Enter()
        {
            
        }

        public override void Tick(float deltaTime)
        {
            if (stateMachine.CustomPhysics.IsGrounded)
            {
                stateMachine.SwitchState(stateMachine.LocomotionState);
            }
        }

        public override void Exit()
        {
        }
    }
}