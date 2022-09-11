using UnityEngine;

namespace Aftermath
{
    public abstract class BhaskaraState : BaseBossState<Bhaskara>
    {
        public BhaskaraState(StateMachine<Bhaskara> machine) : base(machine) {}

        protected void LookAtTarget() => LookAt(Entity.Target.position);

        protected void LookAt(Vector3 target)
        {
            var pos = target;
            pos.y = 0;
            Entity.transform.LookAt(pos);
        }

        protected void MoveFoward(float deltaTime)
        {
            var transform = Entity.transform;
            transform.Translate(transform.forward * Entity._speed * deltaTime, Space.World);
        }
    }

    public class IdleLook : BhaskaraState
    {
        public IdleLook(StateMachine<Bhaskara> machine) : base(machine) {}

        public override void Enter()
        {
            Entity.SetIdle();
            Entity.OnDamaged += ChangeToFollow;
        }

        public override void Tick(float deltaTime) => LookAtTarget();

        public override void Exit()
        {
            Entity.OnDamaged -= ChangeToFollow;
        }

        void ChangeToFollow()
        {
            _stateMachine.SwitchState(new FollowTarget(_stateMachine));
        }
    }

    public class FollowTarget : BhaskaraState
    {
        public FollowTarget(StateMachine<Bhaskara> machine) : base(machine) {}

        public override void Enter() => Entity.SetIdle(false);

        public override void Tick(float deltaTime)
        {
            if (Entity.HealthPercent > 0.2f)
            {
                LookAtTarget();
                MoveFoward(deltaTime);
            }
            else
            {
                _stateMachine.SwitchState(new PrepareToFly(_stateMachine));
            }
        }

        public override void Exit() {}
    }

    public class PrepareToFly : BhaskaraState
    {
        public PrepareToFly(StateMachine<Bhaskara> machine) : base(machine) {}

        public override void Enter()
        {
            LookAt(Entity.FlyStage.transform.position);
            Entity.SetIdle(false);
        }

        public override void Exit() {}

        public override void Tick(float deltaTime)
        {
            var pos = Entity.transform.position;
            var target = Entity.FlyStage.transform.position;
            var dist = Vector3.Distance(pos, target);

            if(dist > 5)
            {
                MoveFoward(deltaTime);
            }
            else
            {
                _stateMachine.SwitchState(new FlyingState(_stateMachine));
            }
        }
    }

    public class FlyingState : BhaskaraState
    {
        public FlyingState(StateMachine<Bhaskara> machine) : base(machine) {}

        private bool _started = false;

        public override void Enter()
        {
            Entity.SetIdle();
            Entity.SetFlying();
            var transform = Entity.transform;
            transform.LookAt(transform.position + Vector3.back);
            var anim = transform.LeanMove(Entity.FlyStage.GetPosition(new Vector2(0.5f, 0.5f)), 2f);

            anim.setOnComplete(() => _started = true);
        }

        public override void Exit() {}

        public override void Tick(float deltaTime)
        {
            if (!_started) return;
        }
    }
}
