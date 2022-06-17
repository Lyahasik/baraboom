using Baraboom.Game.Tools.DiscreteWorld;
using JetBrains.Annotations;
using UnityEngine;

namespace Baraboom.Game.Bombs
{
    [RequireComponent(typeof(DiscreteCollider))]
    public class ExplosionUnit : MonoBehaviour
    {
        #region facade

        public int Damage { private get; set; }

        #endregion

        #region interior

        [SerializeField] private float _duration;

        private void Start()
        {
            Destroy(gameObject, _duration);
        }

        [UsedImplicitly]
        private void OnDiscreteCollision(DiscreteCollider other)
        {
            var damageable = other.GetComponent<IBombTarget>();
            if (damageable != null)
            {
                damageable.TakeDamage(Damage);
                Destroy(gameObject, _duration);
            }
        }

        #endregion
    }
}
