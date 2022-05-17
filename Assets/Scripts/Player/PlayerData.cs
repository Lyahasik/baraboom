using UnityEngine;

namespace Player
{
    public class PlayerData : MonoBehaviour
    {
        [SerializeField] private SOCharacterData _characterData;

        public float Speed => _characterData.Speed;
        public int Range => _characterData.Range;
    }
}
