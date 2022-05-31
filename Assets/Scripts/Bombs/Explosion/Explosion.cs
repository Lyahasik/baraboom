using UnityEngine;

namespace Baraboom
{
    public class Explosion : MonoBehaviour, IExplosion
    {
        #region facade

        int IExplosion.Damage { set => _damage = value; }
        int IExplosion.Range { set => _range = value; }

        #endregion

        #region interior

        [SerializeField] private GameObject _explosionUnitPrefab;
        [SerializeField] private float _explosionUnitGap;
        
        private int _damage;
        private int _range;

        private void Start()
        {
            GenerateWaves();
            Destroy(gameObject);
        }

        #endregion

        private void GenerateWaves()
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
                effect.GetComponent<ExplosionUnit>().Damage = _damage;
            }

            foreach (var direction in directions)
            {
                var waveObject = new GameObject("Explosion Wave");
                waveObject.transform.position = transform.position;

                var wave = waveObject.AddComponent<ExplosionWave>();
                wave.Direction = direction;
                wave.Length = _range + 1;
                wave.ExplosionGenerator = GenerateExplosionUnit;
                wave.ExplosionUnitGap = _explosionUnitGap;
            }
        }
    }
}
