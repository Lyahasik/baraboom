using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Characters.Bots.Tools;
using Baraboom.Game.Characters.Bots.Tools.Navigation;
using Baraboom.Game.Tools;
using Baraboom.Game.Tools.DiscreteWorld;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;
using Logger = Baraboom.Core.Tools.Logging.Logger;

namespace Baraboom.Game.Characters.Bots.Units
{
	[RequireComponent(typeof(DiscreteTransform))]
	public class BotControlUnit : MonoBehaviour, IBotController, IBotRoamingData
	{
		#region facade

		Vector3Int IBotController.Position => _discreteTransform.DiscretePosition;

		bool IBotController.IsMoving => _movementCoroutine != null;

		void IBotController.RequestMovement(Path path)
		{
			if (_movementCoroutine != null)
			{
				_logger.LogError("Shouldn't request new movement before previous is completed or stopped.");
				return;
			}

			_movementCoroutine = StartCoroutine(MovementRoutine(path));
		}

		void IBotController.RequestStop()
		{
			_logger.Log("Stop requested");

			if (_movementCoroutine != null)
				_isStopRequested = true;
		}

		WayPoint[] IBotRoamingData.WayPoints
		{
			get => _wayPoints;
		}

		#endregion

		#region interior

		[SerializeField] private float _stepDuration;
		[SerializeField] private int _botId = -1;

		private Logger _logger;
		private DiscreteTransform _discreteTransform;
		private WayPoint[] _wayPoints;
		private Coroutine _movementCoroutine;
		private bool _isStopRequested;

		[Inject]
		private void Initialize(WayPointProvider wayPointProvider)
		{
			_wayPoints = wayPointProvider.GetWayPoints(_botId).ToArray();
		}

		private void Awake()
		{
			_logger = Logger.For<BotControlUnit>();
			_discreteTransform = GetComponent<DiscreteTransform>();
		}

		[UsedImplicitly]
		private void Terminate()
		{
			Destroy(this);
		}

		private IEnumerator MovementRoutine(IEnumerable<Vector2Int> path)
		{
			_logger.Log("Moving along path {0}", path);

			foreach (var nextPosition in path.Skip(1))
			{
				yield return StepRoutine(nextPosition);
				if (gameObject == null)
					yield break;

				if (_isStopRequested)
				{
					_logger.Log("Stopping at position {0}", _discreteTransform.DiscretePosition);

					_movementCoroutine = null;
					_isStopRequested = false;

					yield break;
				}
			}

			_movementCoroutine = null;
		}

		private IEnumerator StepRoutine(Vector2Int columnPosition)
		{
			return Coroutines.MoveToColumn(_discreteTransform, columnPosition, _stepDuration);
		}

		#endregion
	}
}