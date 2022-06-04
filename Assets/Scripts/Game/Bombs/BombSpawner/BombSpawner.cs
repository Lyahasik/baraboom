using System;
using UnityEngine;

namespace Baraboom.Game.Bombs
{
    public class BombSpawner : MonoBehaviour, IBombSpawner
    {
        #region facade
        
        event Action IBombSpawner.BombExploded
        {
            add => _bombExploded += value;
            remove => _bombExploded -= value;
        }

        int IBombSpawner.DamageMultiplier { set => _damage = value; }

        int IBombSpawner.RangeIncrease { set => _range = value; }

        void IBombSpawner.SpawnBomb(Vector3 position)
        {
            var bombObject = Instantiate(_bombPrefab, position, Quaternion.identity);
            var bomb = bombObject.GetComponent<IBomb>();

            bomb.Exploded += () => _bombExploded?.Invoke();
            bomb.Damage = _damage;
            bomb.Range = _range;
        }

        #endregion
        
        #region interior

        [SerializeField] private GameObject _bombPrefab;

        private Action _bombExploded;
        private int _damage;
        private int _range;

        #endregion
    }
}
