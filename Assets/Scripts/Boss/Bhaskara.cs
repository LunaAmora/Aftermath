using UnityEngine;

namespace Aftermath
{
    [RequireComponent(typeof(BhaskaraStateMachine))]
    public class Bhaskara : Boss
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _target;

        public bool Moving {get; private set;} = false;

        private BhaskaraStateMachine _state;

        void Start()
        {
            _state = GetComponent<BhaskaraStateMachine>();
        }

        void Update()
        {
            var target = _target.position;
            target.y = 0;
            transform.LookAt(target);

            if (Moving)
            {
                transform.Translate(transform.forward * _speed * Time.deltaTime, Space.World);
            }
        }

        public void LookAt(Vector3 dir)
        {
            transform.LookAt(transform.position + dir);
        }

        public void SetFlying(bool value = true)
        {
            _animator.SetBool("Flying", value);
        }

        public void SetIdle(bool value = true)
        {
            _animator.SetBool("Idle", value);
            Moving = !value;
        }

        public void Attack()
        {
            _animator.SetTrigger("Attack");
        }
    }
}
