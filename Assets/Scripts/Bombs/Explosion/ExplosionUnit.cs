using Tools.CollisionInversion;
using UnityEngine;

namespace Baraboom
{
    public class ExplosionUnit : MonoBehaviour, IInvertedTrigger
    {
        #region facade

        public int Damage { private get; set; }

        public void OnInvertedCollision(GameObject target)
        {
            var damageable = target.GetComponent<IDamageable>();
            if (damageable != null)
                damageable.TakeDamage(Damage);
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
