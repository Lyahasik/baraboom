using System;
using UnityEngine;

namespace Baraboom
{
    public class BombSpawner : MonoBehaviour, IBombSpawner
    {
        #region facade
        
        public event Action BombExploded;

        public float DamageMultiplier { private get; set; } = 1f;

        public int RangeIncrease { private get; set; }

        public void SpawnBomb(Vector3 position)
        {
            var bombObject = Instantiate(_bombPrefab, position, Quaternion.identity);
            var bomb = bombObject.GetComponent<IBomb>();

            bomb.Exploded += () => BombExploded?.Invoke();
            bomb.DamageMultiplier = DamageMultiplier;
            bomb.RangeIncrease = RangeIncrease;
        }

        #endregion
        
        #region interior

        [SerializeField] private GameObject _bombPrefab;

        #endregion
    }
}
