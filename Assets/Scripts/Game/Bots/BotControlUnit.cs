using System.Collections;
using System.Collections.Generic;
using Baraboom.Game.Bots.States;
using Baraboom.Game.Tools;
using Baraboom.Game.Tools.Extensions;
using UnityEngine;

namespace Baraboom.Game.Bots
{
	[RequireComponent(typeof(DiscreteTransform))]
	public class BotControlUnit : MonoBehaviour, IControllableBot, IRoamingBot
	{
		#region facade

		Vector2Int IControllableBot.Position => _discreteTransform.DiscretePosition.Make2D();

		bool IControllableBot.IsMoving => _movementCoroutine != null;

		void IControllableBot.Move(IEnumerable<Vector2Int> path)
		{
			if (_movementCoroutine != null)
				StopCoroutine(_movementCoroutine);

			_movementCoroutine = StartCoroutine(MovementRoutine(path));
		}

		WayPoint[] IRoamingBot.WayPoints => _wayPoints;

		#endregion
		
		#region interior

		[SerializeField] private WayPoint[] _wayPoints;

		private DiscreteTransform _discreteTransform;
		private Coroutine _movementCoroutine;

		private void Awake()
		{
			_discreteTransform = GetComponent<DiscreteTransform>();
		}

		private IEnumerator MovementRoutine(IEnumerable<Vector2Int> path)
		{
			foreach (var nextPosition in path)
			{
				SetPosition(nextPosition);
				yield return new WaitForSeconds(0.8f);
			}

			_movementCoroutine = null;
		}

		private void SetPosition(Vector2Int position)
		{
			// TODO Refactor discrete position
			var z = transform.position.z;

			_discreteTransform.DiscretePosition = position.Make3D(0);
			transform.position = transform.position.WithZ(z);
		}

		#endregion
	}
}