using System;
using Baraboom.Game.Tools.DiscreteWorld;
using UnityEngine;
using Zenject;
using Logger = Baraboom.Game.Tools.Logging.Logger;
using Object = UnityEngine.Object;

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

        void IBombSpawner.SpawnBomb(Vector3Int position)
        {
            _logger.Log("Spawning bomb at {0}", position);

            var bomb = _factory.Create(_bombPrefab, DiscreteTranslator.ToContinuous(position));
            bomb.Exploded += () => _bombExploded?.Invoke();
            bomb.Damage = _damage;
            bomb.Range = _range;
        }

        #endregion

        #region interior

        [SerializeField] private GameObject _bombPrefab;

        [Inject] private IFactory<Object, Vector3, Bomb> _factory;

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
