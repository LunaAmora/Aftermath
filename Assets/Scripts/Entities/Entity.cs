using UnityEngine;
using System;

namespace Aftermath
{
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField] private float _maxHealth = 100;
        [ReadOnly] [SerializeField] private float _health;
        [SerializeField] private bool _invulnerable;
        public float _speed;

        public event Action OnDeath;
        public event Action OnDamaged;

        public float HealthPercent => _health/_maxHealth;

        void Awake()
        {
            _health = _maxHealth;
        }

        public void TakeDamage(float damage)
        {
            if (_invulnerable) return;

            _health -= damage;
            OnDamaged?.Invoke();

            if (_health <= 0)
            {
                OnDeath?.Invoke();
            }
        }
    }
}
