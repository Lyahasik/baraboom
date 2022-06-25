using UnityEngine;
using Zenject;

namespace Baraboom.Game.Bombs
{
    public class Explosion : MonoBehaviour
    {
        #region facade

        public int Damage
        {
            set => _damage = value;
        }

        public int Range
        {
            set => _range = value;
        }

        #endregion

        #region interior

        [SerializeField] private GameObject _explosionUnit;
        [SerializeField] private GameObject _explosionWave;
        [SerializeField] private float _explosionUnitGap;
        [SerializeField] private float _ignoreTargetDuration;

        [Inject] private IFactory<Object, Vector3, ExplosionUnit> _explosionUnitFactory;
        [Inject] private IFactory<Object, Vector3, ExplosionWave> _explosionWaveFactory;

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

            foreach (var direction in directions)
            {
                var wave = _explosionWaveFactory.Create(_explosionWave, transform.position);
                wave.Direction = direction;
                wave.Length = _range + 1;
                wave.ExplosionGenerator = GenerateExplosionUnit;
                wave.ExplosionUnitGap = _explosionUnitGap;
            }

            void GenerateExplosionUnit(Vector3 position)
            {
                var unit = _explosionUnitFactory.Create(_explosionUnit, position);
                unit.Damage = _damage;
                unit.IgnoreTargetDuration = _ignoreTargetDuration;
            }
        }
    }
}
