using UnityEngine;

namespace Baraboom
{
    public class Explosion : MonoBehaviour, IExplosion
    {
        #region facade

        public float DamageMultiplier { private get; set; } = 1;
        public int RangeIncrease { private get; set; }

        #endregion

        #region interior

        [SerializeField] private float _baseDamage;
        [SerializeField] private int _baseRange;
        [SerializeField] private GameObject _explosionUnitPrefab;
        [SerializeField] private float _explosionUnitGap;

        private void Start()
        {
            var damage = _baseDamage * DamageMultiplier;
            var range = _baseRange + RangeIncrease;

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
