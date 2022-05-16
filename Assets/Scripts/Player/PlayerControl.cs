using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerData))]
    public class PlayerControl : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private PlayerData _playerData;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _playerData = GetComponent<PlayerData>();
        }

        private void Update()
        {
            Vector3 directionMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
    
            Move(directionMove);
        }

        private void Move(Vector3 direction)
        {
            _rigidbody.MovePosition(_rigidbody.position + direction * _playerData.Speed);
        }
    }
}