using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "SOCharacterData", menuName = "Scriptable Objects/Player/Character Data", order = 1)]
    public class SOCharacterData : ScriptableObject
    {
        private const float SPEED_FACTOR = 0.01f;
    
        [SerializeField] private float _speed;
        [SerializeField] private int _range;

        public float Speed => _speed * SPEED_FACTOR;
        public int Range => _range;
    }
}
