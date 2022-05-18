using UnityEngine;
using Environment.Explosions;

namespace Items
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private GameObject _prefabExplosion;
        [SerializeField] private GameObject _prefabEffect;
    
        [SerializeField] private float _delayExplosion;
        private float _timeExplosion;

        private int _range;
        private int _damage;

        private void Start()
        {
            _timeExplosion = Time.time + _delayExplosion;
        }

        public void Init(int range, int damage)
        {
            _range = range;
            _damage = damage;
        }

        private void Update()
        {
            TryCreateExplosion();
        }

        private void TryCreateExplosion()
        {
            if (_timeExplosion <= Time.time)
            {
                GameObject explosion = Instantiate(_prefabExplosion, transform.position, Quaternion.identity);
                explosion.GetComponent<Explosion>().Init(_prefabEffect, _range, _damage);
            
                Destroy(gameObject);
            }
        }
    }
}
