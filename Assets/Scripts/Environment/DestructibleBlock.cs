using UnityEngine;

namespace Environment
{
    public class DestructibleBlock : Block, ITakingDamage
    {
        [SerializeField] private int _health;

        private bool _isDestroy;
    
        public void TakeDamage(int damage)
        {
            if (_isDestroy == true)
                return;
            
            _health -= damage;

            if (_health <= 0)
                DestructBlock();
        }

        private void DestructBlock()
        {
            ManagerBlocksCensus.RemoveBlock(gameObject);
            _isDestroy = true;
            Destroy(gameObject);
        }
    }
}
