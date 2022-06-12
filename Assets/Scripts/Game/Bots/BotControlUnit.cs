using System;
using System.Collections;
using System.Collections.Generic;
using Baraboom.Game.Bots.States;
using Baraboom.Game.Bots.Tools;
using Baraboom.Game.Tools;
using Baraboom.Game.Tools.Extensions;
using UnityEngine;

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
			Debug.LogFormat("[{0}] Stop requested", typeof(BotControlUnit));

			_isStopRequested = true;
			_onStopped = onStopped;
		}

		WayPoint[] IRoamingBot.WayPoints
		{
			get => _wayPoints;
		}

		#endregion
		
		#region interior

		[SerializeField] private WayPoint[] _wayPoints;
		[SerializeField] private float _pauseBetweenSteps;

		private DiscreteTransform _discreteTransform;
		private Coroutine _movementCoroutine;
		private bool _isStopRequested;
		private Action _onStopped;

		private void Awake()
		{
			_discreteTransform = GetComponent<DiscreteTransform>();
		}

		private IEnumerator MovementRoutine(IEnumerable<Vector2Int> path)
		{
			Debug.LogFormat("[{0}] Moving along path {1}", typeof(BotControlUnit), path);

			foreach (var nextPosition in path)
			{
				SetPosition(nextPosition);
				yield return new WaitForSeconds(_pauseBetweenSteps);

				if (_isStopRequested)
				{
					Debug.LogFormat("[{0}] Stopping at position {1}", typeof(BotControlUnit), _discreteTransform.DiscretePosition);

					_isStopRequested = false;

					_onStopped?.Invoke();
					_onStopped = null;

					break;
				}
			}

			_movementCoroutine = null;
		}

		private void SetPosition(Vector2Int position)
		{
			// TODO Refactor discrete position
			var z = transform.position.z;

			_discreteTransform.DiscretePosition = position.WithZ(0);
			transform.position = transform.position.WithZ(z);
		}

		#endregion
	}
}