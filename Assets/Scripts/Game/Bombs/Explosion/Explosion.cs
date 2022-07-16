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

        [SerializeField] private GameObject _lightingExplosion;
        [SerializeField] private GameObject _explosionUnit;

        [Inject] private IFactory<Object, Vector3, LightingExplosion> _lightingExplosionFactory;
        [Inject] private IFactory<Object, Vector3, ExplosionUnit> _explosionUnitFactory;

        private int _damage;
        private int _range;

        private void Start()
        {
            GenerateLightingExplosions();
            Destroy(gameObject, 1.5f);
        }

        #endregion

        private void GenerateLightingExplosions()
        {
            CreateEpicenterUnit();
            
            var directions = new[]
            {
                Quaternion.Euler(0f, 0f, 0f),
                Quaternion.Euler(0f, 0f, 90f),
                Quaternion.Euler(0f, 0f, -90f),
                Quaternion.Euler(0f, 0f, 180f)
            };

            foreach (Quaternion direction in directions)
            {
                LightingExplosion lightingExplosion = _lightingExplosionFactory.Create(_lightingExplosion, transform.position);
                lightingExplosion.gameObject.transform.rotation = direction;
                
                lightingExplosion.Activate(_explosionUnit, _damage, _range);
            }
        }
        
        private void CreateEpicenterUnit()
        {
            ExplosionUnit unit = _explosionUnitFactory.Create(_explosionUnit, transform.position);
            unit.Damage = _damage;
            unit.IgnoreTargetDuration = 0.5f;
        }
        
    }
}
