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

        private LinkedList<DirectedWave> _waveDirections;
        private int _maxRange;
        private int _currentRange;

        public void Init(GameObject prefabEffect, int range)
        {
            _prefabEffect = prefabEffect;
            
            _timeNextEffect = Time.time;
            
            _maxRange = range;
            _currentRange = 0;
            
            GenerateWaves();
        }

        private void GenerateWaves()
        {
            _waveDirections = new LinkedList<DirectedWave>();

            _waveDirections.AddLast(new DirectedWave(Vector3.right, _maxRange));
            _waveDirections.AddLast(new DirectedWave(-Vector3.right, _maxRange));
            _waveDirections.AddLast(new DirectedWave(Vector3.forward, _maxRange));
            _waveDirections.AddLast(new DirectedWave(-Vector3.forward, _maxRange));
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
            
            Instantiate(_prefabEffect, transform.position, Quaternion.identity);
                
            _currentRange++;
        }

        private void TryIncrementWaves()
        {
            foreach (DirectedWave waveDirection in _waveDirections.ToArray())
            {
                Vector3 positionCreateEffect = waveDirection.GetPositionCreateEffect(transform.position, _currentRange);
            
                if (positionCreateEffect != transform.position)
                {
                    TryCreateWaveEffect(positionCreateEffect);
                
                    continue;
                }
            
                _waveDirections.Remove(waveDirection);
            }
            
            if (_waveDirections.Count == 0)
                Destroy(gameObject);
            
            _currentRange++;
        }

        private void TryCreateWaveEffect(Vector3 positionEffect)
        {
            Instantiate(_prefabEffect, positionEffect, Quaternion.identity);
        }
    }
}
