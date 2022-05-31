using UnityEngine;

namespace Baraboom.Level
{
    [RequireComponent(typeof(IItemSpawner))]
    public sealed class BrittleWall : Wall, IDamageable
    {
        [SerializeField] private int _health;
    
        void IDamageable.TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                GetComponent<IItemSpawner>().TrySpawn();
                Destroy(gameObject);
            }
        }
    }
}
