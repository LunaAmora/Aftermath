using UnityEngine;
using System;

namespace Aftermath
{
    public class Entity : MonoBehaviour
    {
        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private bool _invulnerable;
        private float _health;

        public event Action OnDeath;
        public event Action OnDamaged;

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
