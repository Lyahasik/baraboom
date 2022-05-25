using UnityEngine;

namespace Baraboom
{
    public class Explosion : MonoBehaviour, IExplosion
    {
        #region facade

        float IExplosion.DamageMultiplier { set => _damageMultiplier = value; }
        int IExplosion.RangeIncrease { set => _rangeIncrease = value; }

        #endregion

        #region interior

        [SerializeField] private float _baseDamage;
        [SerializeField] private int _baseRange;
        [SerializeField] private GameObject _explosionUnitPrefab;
        [SerializeField] private float _explosionUnitGap;
        
        private float _damageMultiplier;
        private int _rangeIncrease;

        private void Awake()
        {
            _damageMultiplier = 1f;
        }

        private void Start()
        {
            var damage = _baseDamage * _damageMultiplier;
            var range = _baseRange + _rangeIncrease;

            GenerateWaves(damage, range);
            Destroy(gameObject);
        }

        #endregion

        private void GenerateWaves(float damage, int range)
        {
            var directions = new[]
            {
                Vector3.right,
                Vector3.left,
                Vector3.up,
                Vector3.down
            };

            void GenerateExplosionUnit(Vector3 position)
            {
                var effect = Instantiate(_explosionUnitPrefab, position, Quaternion.identity);
                effect.GetComponent<ExplosionUnit>().Damage = damage;
            }

            foreach (var direction in directions)
            {
                var waveObject = new GameObject("Explosion Wave");
                waveObject.transform.position = transform.position;

                var wave = waveObject.AddComponent<ExplosionWave>();
                wave.Direction = direction;
                wave.Range = range;
                wave.ExplosionGenerator = GenerateExplosionUnit;
                wave.ExplosionUnitGap = _explosionUnitGap;
            }
        }
    }
}
