using System.Collections;
using System.Linq;
using Baraboom.Core.Tools.Extensions;
using Baraboom.Game.Bombs;
using Baraboom.Game.Characters.Player.PlayerInput;
using Baraboom.Game.Level;
using Baraboom.Game.Tools;
using Baraboom.Game.Tools.DiscreteWorld;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;
using Logger = Baraboom.Core.Tools.Logging.Logger;

namespace Baraboom.Game.Characters.Player
{
    [RequireComponent(typeof(DiscreteTransform))]
    public class PlayerController : PausableBehaviour
    {
        [SerializeField] private float _stepDuration;

        [Inject] private ILevel _level;
        [Inject] private IPlayerInputReceiver[] _inputs;

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

        [UsedImplicitly]
        private void Terminate()
        {
            Destroy(this);
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
            if (_inputs.All(input => !input.Bomb))
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

            var movementDirection = _inputs.Select(input => input.Movement).FirstOrDefault(movement => movement != Vector2Int.zero);
            if (movementDirection == Vector2Int.zero)
                return;

            var currentPosition = _discreteTransform.DiscretePosition.XY();
            var desiredPosition = currentPosition + movementDirection;

            var column = _level.BlockMap.GetColumn(desiredPosition);
            if (column is null || !column.Top.IsWalkable)
                return;

            _logger.Log("Moving to {0}", desiredPosition);
            StartCoroutine(StepRoutine(desiredPosition));
        }

        private IEnumerator StepRoutine(Vector2Int columnPosition)
        {
            _isInAnimation = true;
            yield return Coroutines.MoveToColumn(_discreteTransform, columnPosition, _stepDuration / _controllablePlayer.Speed);
            _isInAnimation = false;
        }
    }
}