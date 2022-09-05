using UnityEngine;

namespace Aftermath
{
    public abstract class StateMachine<T> : MonoBehaviour where T : Entity
    {
        private State<T> _currentState;

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
