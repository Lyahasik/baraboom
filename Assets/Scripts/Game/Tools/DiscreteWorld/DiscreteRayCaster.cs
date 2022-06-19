using System;
using System.Collections.Generic;
using System.Linq;
using Baraboom.Game.Tools.Algorithms.Bresenham;
using Baraboom.Game.Tools.Extensions;
using UnityEngine;
using Zenject;

namespace Baraboom.Game.Tools.DiscreteWorld
{
	public sealed class DiscreteRayCaster : MonoBehaviour
	{
		#region facade

		public IEnumerable<DiscreteCollider> CastRay2D(Vector3Int position, Vector3Int target)
		{
			if (position.z != target.z)
				throw new ArgumentException($"{nameof(position)}.z should be equal to {nameof(target)}.z");

			foreach (var point in Bresenham.Iterate(position.XY(), target.XY()).Skip(1))
			{
				foreach (var collider in _colliderRegistry.GetColliders(point.WithZ(position.z)))
					yield return collider;
			}
		}

		#endregion

		#region interior

		[Inject] private DiscreteColliderRegistry _colliderRegistry;

		#endregion
	}
}