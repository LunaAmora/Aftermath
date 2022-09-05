namespace Aftermath
{
    public abstract class State<T> where T : Entity
    {
        protected StateMachine<T> _stateMachine;

        public State(StateMachine<T> machine)
        {
            _stateMachine = machine;
        }

        public abstract void Enter();
        public abstract void Tick(float deltaTime);
        public abstract void Exit();
    }
}
