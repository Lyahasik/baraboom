using Tools;
using UnityEngine;

namespace Baraboom
{
    public class ExplosionUnit : DiscreteCollider
    {
        #region facade

        public int Damage { private get; set; }

        public override void OnCollision(DiscreteCollider other)
        {
            var damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
                damageable.TakeDamage(Damage);

            Destroy(gameObject, _duration);
        }

        #endregion

        #region interior

        [SerializeField] private float _duration;

        private void Start()
        {
            Destroy(gameObject, _duration);
        }

        #endregion
    }
}
