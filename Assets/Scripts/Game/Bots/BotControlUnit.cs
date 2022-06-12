using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Baraboom.Game.Bots.States;
using Baraboom.Game.Bots.Tools;
using Baraboom.Game.Tools;
using Baraboom.Game.Tools.Extensions;
using UnityEngine;
using Logger = Baraboom.Game.Tools.Logging.Logger;

namespace Baraboom.Game.Bots
{
	[RequireComponent(typeof(DiscreteTransform))]
	public class BotControlUnit : MonoBehaviour, IControllableBot, IRoamingBot
	{
		#region facade

		Vector2Int IControllableBot.Position => _discreteTransform.DiscretePosition.XY();

		bool IControllableBot.IsMoving => _movementCoroutine != null;

		void IControllableBot.Move(IEnumerable<Vector2Int> path)
		{
			if (_movementCoroutine != null)
				StopCoroutine(_movementCoroutine);

			_movementCoroutine = StartCoroutine(MovementRoutine(path));
		}

		void IControllableBot.RequestStop(Action onStopped)
		{
			_logger.Log("Stop requested");

			_isStopRequested = true;
			_onStopped = onStopped;
		}

		WayPoint[] IRoamingBot.WayPoints
		{
			get => _wayPoints;
		}

		#endregion

		#region interior

		[SerializeField] private float _pauseBetweenSteps;
		[SerializeField] private int _botId = -1;

		private Logger _logger;
		private DiscreteTransform _discreteTransform;
		private WayPoint[] _wayPoints;
		private Coroutine _movementCoroutine;
		private bool _isStopRequested;
		private Action _onStopped;

		private void Awake()
		{
			_logger = Logger.For<BotControlUnit>();
			_discreteTransform = GetComponent<DiscreteTransform>();
			_wayPoints = WayPointCollector.Collect(_botId).ToArray();
		}

		private IEnumerator MovementRoutine(IEnumerable<Vector2Int> path)
		{
			_logger.Log("Moving along path {0}", path);

			foreach (var nextPosition in path)
			{
				SetPosition(nextPosition);

				if (_isStopRequested)
				{
					_logger.Log("Stopping at position {0}", _discreteTransform.DiscretePosition);

					_isStopRequested = false;

					_onStopped?.Invoke();
					_onStopped = null;

					break;
				}

				yield return new WaitForSeconds(_pauseBetweenSteps);
				if (gameObject == null)
					yield break;
			}

			_movementCoroutine = null;
		}

		private void SetPosition(Vector2Int positionDiscrete)
		{
			var positionContinuous = DiscreteTranslator.ToContinuous(positionDiscrete);

			// TODO Preserve offset
			transform.position = positionContinuous.WithZ(transform.position.z);
		}

		#endregion
	}
}