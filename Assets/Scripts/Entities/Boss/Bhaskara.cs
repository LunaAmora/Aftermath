using UnityEngine;

namespace Aftermath
{
    [RequireComponent(typeof(BhaskaraStateMachine))]
    public class Bhaskara : Boss
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _target;
        [SerializeField] private BossFlyingStage _flyStage;

        public Transform Target => _target;
        public BossFlyingStage FlyStage => _flyStage;

        private BhaskaraStateMachine _state;
        private SoundPlayer _soundplayer;

        void Start()
        {
            _state = GetComponent<BhaskaraStateMachine>();
            _soundplayer = SoundPlayer.Instance;
            _state.Initialize(this);
            OnDeath += Death;
            OnDamaged += Damaged;
            Idle();
        }

        void Death()
        {
            gameObject.SetActive(false);
            _soundplayer.StopMusic();
            _soundplayer.PlayAudio(SoundPlayer.AudioEnum.DerrotaBhaskara);
            _soundplayer.OnMusicEnd += ()
                => GameManager.Instance.Victory();
        }

        void Damaged() => _soundplayer.PlayAudio(SoundPlayer.AudioEnum.DanoBhaskara);

        [ContextMenu("Idle")]
        public void Idle()
        {
            _state.SwitchState(new IdleLook(_state));
        }

        [ContextMenu("Follow")]
        public void Follow()
        {
            _state.SwitchState(new FollowTarget(_state));
        }

        [ContextMenu("Prepare to fly")]
        public void Fly()
        {
            _state.SwitchState(new PrepareToFly(_state));
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
        }

        public void Attack()
        {
            _animator.SetTrigger("Attack");
        }
    }
}
