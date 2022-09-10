namespace Aftermath
{
    public abstract class BaseBossState<T> : State<T> where T : Boss
    {
        protected BaseBossState(StateMachine<T> machine) : base(machine) {}
    }
}
