using UnityEngine;

namespace FSM.Player
{
    public class PlayerJumpState : PlayerBaseState
    {
        public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            stateMachine.CustomPhysics.Jump(true);
        }

        public override void Tick(float deltaTime)
        {
            Debug.Log("Jumping...");
            if (stateMachine.CustomPhysics.GetVelocity.y < 0) 
                stateMachine.SwitchState(new PlayerFallingState(stateMachine));
        }

        public override void Exit()
        {
        }
    }
}