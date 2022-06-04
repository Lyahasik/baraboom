using System.Collections.Generic;
using UnityEngine;

namespace Baraboom.Game.Tools
{
	public class DiscreteCollisionDetector : MonoBehaviour
	{
		#region facade

		public void RegisterCollider(DiscreteCollider collider)
		{
			_colliders.Add(collider);
			_transforms.Add(collider.GetComponent<DiscreteTransform>());

			collider.Destroyed += () =>
			{
				var index = _colliders.FindIndex(test => test == collider);
				if (index == -1)
				{
					Debug.LogError("Collider not found");
					return;
				}

				_colliders.RemoveAt(index);
				_transforms.RemoveAt(index);
			};
		}

		#endregion

		#region interior

		private readonly List<DiscreteCollider> _colliders = new();
		private readonly List<DiscreteTransform> _transforms = new();

		private void FixedUpdate()
		{
			for (var i = 0; i < _colliders.Count; i++)
			for (var j = i + 1; j < _colliders.Count; j++)
			{
				if (_transforms[i].DiscretePosition != _transforms[j].DiscretePosition)
					continue;

				_colliders[i].OnCollision(_colliders[j]);
				_colliders[j].OnCollision(_colliders[i]);
			}
		}

		#endregion
	}
}