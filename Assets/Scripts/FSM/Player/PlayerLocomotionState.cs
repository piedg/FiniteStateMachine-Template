using Inputs;
using UnityEngine;

namespace FSM.Player
{
    public class PlayerLocomotionState : PlayerBaseState
    {
        public PlayerLocomotionState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
            
        }

        public override void Enter()
        {
            InputManager.Instance.OnJump += Jump;
        }

        public override void Tick(float deltaTime)
        {
            stateMachine.Movement.SetCurrentDirection(stateMachine.InputManager.GetMovementVectorNormalized().x);
        }

        public override void Exit()
        {
            InputManager.Instance.OnJump -= Jump;
        }
    }
}