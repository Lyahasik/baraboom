using UnityEngine;

namespace Environment.Explosions
{
    public class EffectExplosion : MonoBehaviour
    {
        [SerializeField] private float _timeLife;
        private float _timeDeath;

        private int _damage;

        public int Damage
        {
            set => _damage = (value > 1) ? value : 1;
        }

        private void Start()
        {
            _timeDeath = Time.time + _timeLife;
        }

        private void Update()
        {
            if (_timeDeath <= Time.time)
                Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            ITakingDamage takingDamage = other.GetComponent<ITakingDamage>();

            if (takingDamage != null)
            {
                takingDamage.TakeDamage(_damage);
            }
        }
    }
}
