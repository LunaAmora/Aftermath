using UnityEngine;

namespace Aftermath
{
    public abstract class StateMachine<T> : MonoBehaviour where T : Entity
    {
        public T Entity {get; private set;}
        private State<T> _currentState;

        public void Initialize(T entity)
        {
            Entity = entity;
        }

        public void SwitchState(State<T> state)
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        void Update()
        {
            _currentState?.Tick(Time.deltaTime);
        }
    }
}
