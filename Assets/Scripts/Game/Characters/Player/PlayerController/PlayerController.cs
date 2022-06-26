using System.Collections;
using Baraboom.Game.Bombs;
using Baraboom.Game.Level;
using Baraboom.Game.Level.Environment;
using Baraboom.Game.Tools;
using Baraboom.Game.Tools.DiscreteWorld;
using Baraboom.Game.Tools.Extensions;
using UnityEngine;
using Zenject;
using Logger = Baraboom.Game.Tools.Logging.Logger;

namespace Baraboom.Game.Characters.Player
{
    [RequireComponent(typeof(DiscreteTransform))]
    public class PlayerController : GameBehaviour
    {
        [SerializeField] private float _stepDuration;

        [Inject] private ILevel _level;

        private Logger _logger;
        private DiscreteTransform _discreteTransform;
        private IControllablePlayer _controllablePlayer;
        private IBombSpawner _bombSpawner;
        private bool _isInAnimation;

        private void Awake()
        {
            _logger = Logger.For<PlayerController>();
            _discreteTransform = GetComponent<DiscreteTransform>();
        }

        private void Start()
        {
            _controllablePlayer = GetComponent<IControllablePlayer>();

            _bombSpawner = FindObjectOfType<BombSpawner>();
            _bombSpawner.BombExploded += _controllablePlayer.RemovePlantedBomb;
        }

        protected override void UpdateIfNotPaused()
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
            _bombSpawner.SpawnBomb(_discreteTransform.DiscretePosition);
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

            _logger.Log("Moving to {0}", desiredPosition);
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
            _isInAnimation = true;
            yield return Coroutines.MoveToColumn(_discreteTransform, columnPosition, _stepDuration / _controllablePlayer.Speed);
            _isInAnimation = false;
        }
    }
}