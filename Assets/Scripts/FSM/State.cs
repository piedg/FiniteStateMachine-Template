namespace FSM
{
    public abstract class State
    {
        public string StateName;
        
        public abstract void Enter();
        public abstract void Tick(float deltaTime);
        public abstract void Exit();
    }
}