using System.Collections;
using Baraboom.Game.Bombs;
using Baraboom.Game.Level;
using Baraboom.Game.Tools;
using Baraboom.Game.Tools.Extensions;
using UnityEngine;

namespace Baraboom.Game.Player
{
    [RequireComponent(typeof(DiscreteTransform))]
    public class PlayerController : MonoBehaviour
    {
        #region facade

        [SerializeField] private float m_StepDuration;

        #endregion

        #region interior

        private DiscreteTransform _discreteTransform;
        private ILevel _level;
        private IControllablePlayer _controllablePlayer;
        private IBombSpawner _bombSpawner;
        private bool _isInAnimation;

        private void Awake()
        {
            _discreteTransform = GetComponent<DiscreteTransform>();
        }

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

            _bombSpawner.DamageMultiplier = _controllablePlayer.ExplosionDamage;
            _bombSpawner.RangeIncrease = _controllablePlayer.ExplosionRange;
            _bombSpawner.SpawnBomb(transform.position);
        }

        private void ProcessMovement()
        {
            if (_isInAnimation)
                return;

            var movementDirection = GetMovementDirection();
            if (movementDirection == null)
                return;

            var currentPosition = _discreteTransform.DiscretePosition.XY();
            var desiredPosition = currentPosition + movementDirection.Value;

            var column = _level.BlockMap.GetColumn(desiredPosition);
            if (column is null || column.Top is Wall)
                return;

            StartCoroutine(StepRoutine(desiredPosition));
        }

        private static Vector2Int? GetMovementDirection()
        {
            if (Input.GetKey(KeyCode.A))
                return new Vector2Int(-1, 0);
            if (Input.GetKey(KeyCode.D))
                return new Vector2Int(+1, 0);
            if (Input.GetKey(KeyCode.W))
                return new Vector2Int(0, +1);
            if (Input.GetKey(KeyCode.S))
                return new Vector2Int(0, -1);

            return null;
        }

        private IEnumerator StepRoutine(Vector2Int columnPosition)
        {
            var startPosition = transform.position;
            var targetPosition = DiscreteTranslator.ToContinuous(columnPosition).WithZ(startPosition.z);

            _isInAnimation = true;

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