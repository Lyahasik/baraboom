using System.Collections;
using Baraboom.Game.Bombs;
using Baraboom.Game.Level;
using Baraboom.Game.Level.Environment;
using Baraboom.Game.Tools;
using UnityEngine;
using UnityEngine.VFX;
using Zenject;

using Baraboom.Game.Tools.DiscreteWorld;

namespace Baraboom
{
    [RequireComponent(typeof(VisualEffect))]
    public class LightingExplosion : MonoBehaviour
    {
        private const float OffsetExplosion = 0.5f;
        
        private readonly int _lifetimeId = Shader.PropertyToID("Lifetime");
        private readonly int _impactOffsetId = Shader.PropertyToID("ImpactOffset");
        private readonly int _lengthId = Shader.PropertyToID("Length");

        [Inject] private ILevel _level;
        [Inject] private IFactory<Object, Vector3, ExplosionUnit> _explosionUnitFactory;

        private GameObject _explosionUnit;
        private VisualEffect _visualEffect;
        private float _lifeTime;

        private void Awake()
        {
            _visualEffect = GetComponent<VisualEffect>();
            _lifeTime = _visualEffect.GetFloat(_lifetimeId);
        }

        public void Activate(GameObject explosionUnit, int damage, float range)
        {
            float distance = DetermineDistance(damage, range);
            _explosionUnit = explosionUnit;

            _visualEffect.SetFloat(_impactOffsetId, -distance);
            _visualEffect.SetFloat(_lengthId, distance);
            
            _visualEffect.Play();
            
            Destroy(gameObject, _lifeTime + 0.1f);
        }

        private float DetermineDistance(int damage, float range)
        {
            Vector3 currentPosition = transform.position;
            Vector3 direction = -transform.up;

            for (int distance = 0; distance < range; distance++)
            {
                currentPosition += direction;
                Vector3Int discretePosition = DiscreteTranslator.ToDiscrete(currentPosition);

                StartCoroutine(CreateUnit(damage, currentPosition));
                
                if (_level.BlockMap.GetBlock(discretePosition))
                    return distance + OffsetExplosion;
            }

            return range;
        }

        public IEnumerator CreateUnit(int damage, Vector3 position)
        {
            yield return new WaitForSeconds(0.1f);
            
            ExplosionUnit unit = _explosionUnitFactory.Create(_explosionUnit, position);
            unit.Damage = damage;
            unit.IgnoreTargetDuration = _lifeTime;
        }
    }
}
