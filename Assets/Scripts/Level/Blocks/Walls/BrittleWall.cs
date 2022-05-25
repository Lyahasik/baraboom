using UnityEngine;

namespace Baraboom.Level
{
    public sealed class BrittleWall : Wall, IDamageable
    {
        [SerializeField] private float _health;
    
        public void TakeDamage(float damage)
        {
            _health -= damage;
            if (_health <= 0)
                Destroy(gameObject);
        }
    }
}