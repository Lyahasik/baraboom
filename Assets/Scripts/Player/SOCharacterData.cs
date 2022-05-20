using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "SOCharacterData", menuName = "Scriptable Objects/Player/Character Data", order = 1)]
    public class SOCharacterData : ScriptableObject
    {
        [SerializeField] private int _maxNumberPlantedBombs;
        [SerializeField] private int _health;
        [SerializeField] private int _damage;
        [SerializeField] private int _range;
        [SerializeField] private float _speed;

        public int MaxNumberPlantedBombs => _maxNumberPlantedBombs;
        public int Health => _health;
        public int Damage => _damage;
        public int Range => _range;
        public float Speed => _speed;
    }
}
