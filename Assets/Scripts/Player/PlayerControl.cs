using System;
using UnityEngine;

using Environment;
using Events;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(PlayerData))]
    public class PlayerControl : MonoBehaviour
    {
        private SpawnerBombs _spawnerBombs;
        
        private Rigidbody _rigidbody;
        private PlayerData _playerData;

        [SerializeField] private GameObject _prefabBomb;
        private GameObject _lastPlantBomb;

        private Vector3 _directionMove;

        private void Start()
        {
            _spawnerBombs = FindObjectOfType<SpawnerBombs>();
            
            _rigidbody = GetComponent<Rigidbody>();
            _playerData = GetComponent<PlayerData>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlantBomb();
            }
            
            UpdateDirectionMove(new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")));
        }

        public void UpdateDirectionMove(Vector3 direction)
        {
            _directionMove = direction;
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = Vector3.zero;
            
            if (_lastPlantBomb != null
                && CheckFarEnoughBomb())
            {
                Physics.IgnoreCollision(_lastPlantBomb.GetComponent<Collider>(), GetComponent<Collider>(), false);
                _lastPlantBomb = null;
            }
            
            Move();
        }

        private void Move()
        {
            _rigidbody.AddForce(_directionMove * _playerData.Speed);
        }

        private void PlantBomb()
        {
            if (_playerData.IsBombsLeft()
                && _lastPlantBomb == null)
            {
                _lastPlantBomb = _spawnerBombs.SpawnBomb(transform.position, _prefabBomb, _playerData.Range, _playerData.Damage);
                Physics.IgnoreCollision(_lastPlantBomb.GetComponent<Collider>(), GetComponent<Collider>(), true);

                ManagerDataPlayer.IncrementNumberPlantedBombs();
            }
        }

        private bool CheckFarEnoughBomb()
        {
            if (Math.Abs(_lastPlantBomb.transform.position.x - transform.position.x) >= 1.0f
                || Math.Abs(_lastPlantBomb.transform.position.z - transform.position.z) >= 1.0f)
            {
                return true;
            }

            return false;
        }
    }
}