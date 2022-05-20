using UnityEngine;

namespace Items
{
    public abstract class BaseItem : MonoBehaviour, ITakingDamage
    {
        private int _health = 1;

        private bool _isDestroy;
    
        public void TakeDamage(int damage)
        {
            if (_isDestroy == true)
                return;
            
            _health -= damage;

            if (_health <= 0)
                DestructItem();
        }
    
        protected void DestructItem()
        {
            _isDestroy = true;
            Destroy(gameObject);
        }
    }
}
