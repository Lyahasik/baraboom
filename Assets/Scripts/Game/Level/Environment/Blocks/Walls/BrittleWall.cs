using Baraboom.Game.Bombs;
using Baraboom.Game.Level.Items;
using UnityEngine;

namespace Baraboom.Game.Level.Environment
{
    [RequireComponent(typeof(IItemSpawner))]
    public sealed class BrittleWall : Wall, IBombTarget
    {
        [SerializeField] private int _health;

        void IBombTarget.TakeDamage(int damage)
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