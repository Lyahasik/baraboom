using System.Collections.Generic;
using Baraboom.Game.Tools.Extensions;
using UnityEngine;

namespace Baraboom.Game.Tools.DiscreteWorld
{
	public class DiscreteColliderRegistry : MonoBehaviour
	{
		#region facade

		public IReadOnlyList<DiscreteCollider> AllColliders => _colliders;

		public DiscreteCollider GetCollider(Vector3Int position)
		{
			return _collidersByPosition.Get(position);
		}

		public void RegisterCollider(DiscreteCollider collider)
		{
			_colliders.Add(collider);
			_collidersByPosition[collider.Transform.DiscretePosition] = collider;

			collider.Transform.DiscretePositionChanging += () =>
			{
				_collidersByPosition.Remove(collider.Transform.DiscretePosition);
			};

			collider.Transform.DiscretePositionChanged += () =>
			{
				_collidersByPosition[collider.Transform.DiscretePosition] = collider;
			};

			collider.Destroyed += () =>
			{
				_colliders.Remove(collider);
				_collidersByPosition.Remove(collider.Transform.DiscretePosition);
			};
		}

		#endregion

		#region interior

		private readonly List<DiscreteCollider> _colliders = new();
		private readonly Dictionary<Vector3Int, DiscreteCollider> _collidersByPosition = new();

		#endregion
	}
}