using UnityEngine;

namespace FSM.Player
{
    public class PlayerJumpState : PlayerBaseState
    {
        public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
            StateName = "Jump";
        }

        public override void Enter()
        {
            stateMachine.CustomPhysics.Jump(true);
        }

        public override void Tick(float deltaTime)
        {
            Fall();
        }

        public override void Exit()
        {
        }
    }
}