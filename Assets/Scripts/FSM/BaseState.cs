namespace FSM
{
    public abstract class BaseState : State
    {
        protected StateMachine stateMachine;

        public BaseState(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
    }
}