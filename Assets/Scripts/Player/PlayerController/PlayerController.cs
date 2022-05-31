using System.Collections;
using Baraboom.Level;
using UnityEngine;

namespace Baraboom
{
    public class PlayerController : MonoBehaviour
    {
        #region facade

        [SerializeField] private float m_StepDuration;

        #endregion

        #region interior

        private ILevel _level;
        private IControllablePlayer _controllablePlayer;
        private IBombSpawner _bombSpawner;
        private bool _isInAnimation;

        private void Start()
        {
            _controllablePlayer = GetComponent<IControllablePlayer>();

            _bombSpawner = FindObjectOfType<BombSpawner>();
            _bombSpawner.BombExploded += _controllablePlayer.RemovePlantedBomb;

            _level = GameObject.Find("Level").GetComponent<ILevel>(); // TODO Injection
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
            if (!_controllablePlayer.HaveBombs)
                return;

            _controllablePlayer.AddPlantedBomb();

            _bombSpawner.DamageMultiplier = _controllablePlayer.DamageMultiplier;
            _bombSpawner.RangeIncrease = _controllablePlayer.RangeIncrease;
            _bombSpawner.SpawnBomb(transform.position);
        }

        private void ProcessMovement()
        {
            if (_isInAnimation)
                return;

            var movementDirection = GetMovementDirection();
            if (movementDirection == null)
                return;

            var currentPosition = _level.WorldToCell(transform.position);
            var desiredPosition = currentPosition + movementDirection;

            var block = _level.GetTopBlock(desiredPosition.Value);
            if (block is not Ground)
                return;

            StartCoroutine(StepRoutine(transform.position + movementDirection.Value));
        }

        private Vector3Int? GetMovementDirection()
        {
            if (Input.GetKey(KeyCode.A))
                return new Vector3Int(-1, 0, 0);
            if (Input.GetKey(KeyCode.D))
                return new Vector3Int(+1, 0, 0);
            if (Input.GetKey(KeyCode.W))
                return new Vector3Int(0, +1, 0);
            if (Input.GetKey(KeyCode.S))
                return new Vector3Int(0, -1, 0);

            return null;
        }

        private IEnumerator StepRoutine(Vector3 targetPosition)
        {
            _isInAnimation = true;

            var startPosition = transform.position;

            var duration = m_StepDuration / _controllablePlayer.Speed;
            var startTime = Time.time;
            var finishTime = startTime + duration;
            
            for (var currentTime = startTime; currentTime < finishTime; currentTime = Time.time)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, (currentTime - startTime) / duration);
                yield return null;
            }

            transform.position = targetPosition;

            _isInAnimation = false;
        }

        #endregion
    }
}