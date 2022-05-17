using UnityEngine;

namespace Environment.Explosions
{
    public class EffectExplosion : MonoBehaviour
    {
        [SerializeField] private float _timeLife;
        private float _timeDeath;

        private void Start()
        {
            _timeDeath = Time.time + _timeLife;
        }

        private void Update()
        {
            if (_timeDeath <= Time.time)
                Destroy(gameObject);
        }
    }
}
