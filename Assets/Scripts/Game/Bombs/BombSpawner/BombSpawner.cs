using System;
using UnityEngine;
using Logger = Baraboom.Game.Tools.Logging.Logger; 

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
            _logger.Log("Spawning bomb at {0}", position);

            var bombObject = Instantiate(_bombPrefab, position, Quaternion.identity);
            var bomb = bombObject.GetComponent<IBomb>();

            bomb.Exploded += () => _bombExploded?.Invoke();
            bomb.Damage = _damage;
            bomb.Range = _range;
        }

        #endregion

        #region interior

        [SerializeField] private GameObject _bombPrefab;

        private Logger _logger;
        private Action _bombExploded;
        private int _damage;
        private int _range;

        private void Awake()
        {
            _logger = Logger.For<BombSpawner>();
        }

        #endregion
    }
}
