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
    public class LightingExplosion : Killer<IBombTarget>
    {
        private const float OffsetExplosion = 0.5f;
        
        private readonly int _lifetimeId = Shader.PropertyToID("Lifetime");
        private readonly int _impactOffsetId = Shader.PropertyToID("ImpactOffset");
        private readonly int _lengthId = Shader.PropertyToID("Length");

        [Inject] private ILevel _level;
            
        private VisualEffect _visualEffect;
        private ITarget _target;

        private void Awake()
        {
            _visualEffect = GetComponent<VisualEffect>();
        }

        public void Activate(int damage, float range)
        {
            float distance = DetermineDistance(range);

            _visualEffect.SetFloat(_impactOffsetId, -distance);
            _visualEffect.SetFloat(_lengthId, distance);
            
            _visualEffect.Play();
            
            if (_target != null)
                StartCoroutine(MakeDamage(damage));
        }

        private float DetermineDistance(float range)
        {
            Vector3 currentPosition = transform.position;
            Vector3 direction = -transform.up;

            for (int distance = 0; distance < range; distance++)
            {
                currentPosition += direction;
                
                Vector3Int discretePosition = DiscreteTranslator.ToDiscrete(currentPosition);
                Block block = _level.BlockMap.GetBlock(discretePosition);
                if (block)
                {
                    _target = block.GetComponent<ITarget>();
                    
                    return distance + OffsetExplosion;
                }
            }

            return range;
        }

        private IEnumerator MakeDamage(int damage)
        {
            yield return new WaitForSeconds(_visualEffect.GetFloat(_lifetimeId));
            
            _target.TakeDamage(damage);
        }
    }
}
