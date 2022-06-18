using System.Collections.Generic;
using Baraboom.Game.Tools.Collections;
using UnityEngine;

namespace Baraboom.Game.Tools.DiscreteWorld
{
	public class DiscreteColliderRegistry : MonoBehaviour
	{
		#region facade

		public IEnumerable<DiscreteCollider> AllColliders => _colliders;

		public IEnumerable<DiscreteCollider> GetColliders(Vector3Int position)
		{
			return _collidersByPosition.Get(position);
		}

		public void RegisterCollider(DiscreteCollider collider)
		{
			_colliders.Add(collider);
			_collidersByPosition.Add(collider.Transform.DiscretePosition, collider);

			collider.Transform.DiscretePositionChanging += () =>
			{
				_collidersByPosition.RemoveValueByHint(collider.Transform.DiscretePosition, collider);
			};

			collider.Transform.DiscretePositionChanged += () =>
			{
				_collidersByPosition.Add(collider.Transform.DiscretePosition, collider);
			};

			collider.Destroyed += () =>
			{
				_colliders.Remove(collider);
				_collidersByPosition.RemoveValueByHint(collider.Transform.DiscretePosition, collider);
			};
		}

		#endregion

		#region interior

		private readonly List<DiscreteCollider> _colliders = new();
		private readonly MultiDictionary<Vector3Int, DiscreteCollider> _collidersByPosition = new();

		#endregion
	}
}