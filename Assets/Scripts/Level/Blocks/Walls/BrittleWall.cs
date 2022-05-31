using UnityEngine;

namespace Baraboom.Level
{
    public sealed class BrittleWall : Wall, IDamageable
    {
        [SerializeField] private int _health;
    
        void IDamageable.TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
                Destroy(gameObject);
        }
    }
}
