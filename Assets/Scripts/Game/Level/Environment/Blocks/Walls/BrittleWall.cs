using Baraboom.Game.Bombs;
using Baraboom.Game.Level.Items;
using Baraboom.Game.Tools;
using UnityEngine;

namespace Baraboom.Game.Level.Environment
{
    [RequireComponent(typeof(IItemSpawner))]
    public sealed class BrittleWall : Wall, IBombTarget
    {
        private readonly int _animationDieId = Animator.StringToHash("Die");
        
        [SerializeField] private int _health;
        [SerializeField] private int _delayDie;

        void ITarget.TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                GetComponent<IItemSpawner>().TrySpawn();
                
                GetComponentInChildren<Animator>().SetTrigger(_animationDieId);
                
                Destroy(gameObject, _delayDie);
            }
        }
    }
}
