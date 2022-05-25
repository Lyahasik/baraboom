using Baraboom.Level;
using UnityEngine;

namespace Baraboom
{
    public class PlayerController : MonoBehaviour
    {
        private Level.Level _level;
        private IPlayer _player;
        private IBombSpawner _bombSpawner;

        private void Start()
        {
            _player = GetComponent<IPlayer>();

            _bombSpawner = FindObjectOfType<BombSpawner>();
            _bombSpawner.BombExploded += _player.RemovePlantedBomb;

            _level = GameObject.Find("Level").GetComponent<Level.Level>(); // TODO
        }

        private void Update()
        {
            ProcessPlanting();
            ProcessMovement();
        }

        private void ProcessPlanting()
        {
            if (!Input.GetKeyDown(KeyCode.Space))
                return;
            if (!_player.HaveBombs)
                return;

            _player.AddPlantedBomb();

            _bombSpawner.DamageMultiplier = _player.DamageMultiplier;
            _bombSpawner.RangeIncrease = _player.RangeIncrease;
            _bombSpawner.SpawnBomb(transform.position);
        }

        private void ProcessMovement()
        {
            var movementDirection = GetMovementDirection();
            if (movementDirection == null)
                return;

            var currentPosition = _level.WorldToCell(transform.position);
            var desiredPosition = currentPosition + movementDirection;

            var block = _level.GetTopBlock(desiredPosition.Value);
            if (block is not Ground)
                return;

            transform.position += movementDirection.Value; 
        }

        private Vector3Int? GetMovementDirection()
        {
            if (Input.GetKeyDown("a"))
                return new Vector3Int(-1, 0, 0);
            if (Input.GetKeyDown("d"))
                return new Vector3Int(+1, 0, 0);
            if (Input.GetKeyDown("w"))
                return new Vector3Int(0, +1, 0);
            if (Input.GetKeyDown("s"))
                return new Vector3Int(0, -1, 0);

            return null;
        }
    }
}