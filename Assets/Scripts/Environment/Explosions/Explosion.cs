using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Environment.Explosions
{
    public class Explosion : MonoBehaviour
    {
        private GameObject _prefabEffect;
        
        [SerializeField] private float _delayNextEffect;
        private float _timeNextEffect;

        private LinkedList<DirectedWave> _directedWaves;
        private int _maxRange;
        private int _currentRange;
        private int _damage;
        

        public void Init(GameObject prefabEffect, int range, int damage)
        {
            _prefabEffect = prefabEffect;

            _timeNextEffect = Time.time;
            
            _maxRange = range;
            _currentRange = 0;
            _damage = damage;
            
            GenerateWaves();
        }

        private void GenerateWaves()
        {
            _directedWaves = new LinkedList<DirectedWave>();

            _directedWaves.AddLast(new DirectedWave(Vector3.right, _maxRange));
            _directedWaves.AddLast(new DirectedWave(-Vector3.right, _maxRange));
            _directedWaves.AddLast(new DirectedWave(Vector3.forward, _maxRange));
            _directedWaves.AddLast(new DirectedWave(-Vector3.forward, _maxRange));
        }
        
        private void Update()
        {
            TryIncrementExplosion();
        }

        private void TryIncrementExplosion()
        {
            if (_timeNextEffect <= Time.time)
            {
                TryCreateHypocentreEffect();
                TryIncrementWaves();
                
                _timeNextEffect = Time.time + _delayNextEffect;
            }
        }

        private void TryCreateHypocentreEffect()
        {
            if (_currentRange != 0)
                return;
            
            CreateEffect(transform.position);
                
            _currentRange++;
        }

        private void TryIncrementWaves()
        {
            foreach (DirectedWave directedWave in _directedWaves.ToArray())
            {
                Vector3 positionCreateEffect = directedWave.GetPositionCreateEffect(transform.position, _currentRange);

                if (positionCreateEffect == transform.position)
                {
                    _directedWaves.Remove(directedWave);
                }
                else
                {
                    TryCreateWaveEffect(directedWave, positionCreateEffect);
                }
            }
            
            if (_directedWaves.Count == 0)
                Destroy(gameObject);
            
            _currentRange++;
        }

        private void TryCreateWaveEffect(DirectedWave directedWave, Vector3 positionEffect)
        {
            GameObject block = ManagerBlocksCensus.TryGetBlockByPosition(positionEffect);

            if (block == null)
            {
                CreateEffect(positionEffect);
            }
            else
            {
                if (block.GetComponent<DestructibleBlock>() != null)
                    CreateEffect(positionEffect);
                    
                _directedWaves.Remove(directedWave);
            }
        }

        private void CreateEffect(Vector3 position)
        {
            GameObject effect = Instantiate(_prefabEffect, position, Quaternion.identity);
            effect.GetComponent<EffectExplosion>().Damage = _damage;
        }
    }
}