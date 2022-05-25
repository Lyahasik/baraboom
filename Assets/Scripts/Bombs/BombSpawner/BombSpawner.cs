using System;
using UnityEngine;

namespace Baraboom
{
    public class BombSpawner : MonoBehaviour, IBombSpawner
    {
        #region facade
        
        event Action IBombSpawner.BombExploded
        {
            add => _bombExploded += value;
            remove => _bombExploded -= value;
        }

        float IBombSpawner.DamageMultiplier { set => _damageMultiplier = value; }

        int IBombSpawner.RangeIncrease { set => _rangeIncrease = value; }

        void IBombSpawner.SpawnBomb(Vector3 position)
        {
            var bombObject = Instantiate(_bombPrefab, position, Quaternion.identity);
            var bomb = bombObject.GetComponent<IBomb>();

            bomb.Exploded += () => _bombExploded?.Invoke();
            bomb.DamageMultiplier = _damageMultiplier;
            bomb.RangeIncrease = _rangeIncrease;
        }

        #endregion
        
        #region interior

        [SerializeField] private GameObject _bombPrefab;

        private Action _bombExploded;
        private float _damageMultiplier;
        private int _rangeIncrease;

        private void Awake()
        {
            _damageMultiplier = 1;
        }

        #endregion
    }
}
