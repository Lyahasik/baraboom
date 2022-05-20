using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "SOCharacterData", menuName = "Scriptable Objects/Player/Character Data", order = 1)]
    public class SOCharacterData : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _range;
        [SerializeField] private int _damage;

        public float Speed => _speed;
        public int Range => _range;
        public int Damage => _damage;
    }
}
