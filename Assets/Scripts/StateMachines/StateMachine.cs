using UnityEngine;

namespace Aftermath
{
    [RequireComponent(typeof(Entity))]
    public abstract class StateMachine<T> : MonoBehaviour where T : Entity
    {
        public T Entity {get; private set;}
        private State<T> _currentState;

        void Start() => Entity = GetComponent<T>();

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
