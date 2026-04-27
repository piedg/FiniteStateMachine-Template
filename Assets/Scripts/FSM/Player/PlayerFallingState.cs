using UnityEngine;

namespace FSM.Player
{
    public class PlayerFallingState : PlayerBaseState
    {
        public PlayerFallingState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            
        }

        public override void Tick(float deltaTime)
        {
            Debug.Log("Falling...");
            if (stateMachine.CustomPhysics.IsGrounded)
            {
                stateMachine.SwitchState(new PlayerLocomotionState(stateMachine));
            }
        }

        public override void Exit()
        {
        }
    }
}