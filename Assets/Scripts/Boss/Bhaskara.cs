using UnityEngine;

namespace Aftermath
{
    [RequireComponent(typeof(BhaskaraStateMachine))]
    public class Bhaskara : Boss
    {
        private BhaskaraStateMachine _state;

        void Start()
        {
            _state = GetComponent<BhaskaraStateMachine>();
        }
    }
}
