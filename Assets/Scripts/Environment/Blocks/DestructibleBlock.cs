using UnityEngine;

namespace Baraboom.Blocks
{
    public class DestructibleBlock : Block, IDamageable
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
