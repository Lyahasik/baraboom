using System.Linq;
using Baraboom.Game.Tools.DiscreteWorld;
using UnityEngine;

namespace Baraboom.Game.Tools
{
	public class DiscreteCollisionDetector : MonoBehaviour
	{
		private DiscreteColliderRegistry _colliderRegistry;

		private void Awake()
		{
			_colliderRegistry = GameObject.Find("DiscreteColliderRegistry").GetComponent<DiscreteColliderRegistry>();
		}

		private void FixedUpdate()
		{
			var colliders = _colliderRegistry.AllColliders.ToArray();

			for (var i = 0; i < colliders.Length; i++)
			for (var j = i + 1; j < colliders.Length; j++)
			{
				if (colliders[i].Transform.DiscretePosition != colliders[j].Transform.DiscretePosition)
					continue;

				colliders[i].gameObject.BroadcastMessage("OnDiscreteCollision", colliders[j], SendMessageOptions.DontRequireReceiver);
				colliders[j].gameObject.BroadcastMessage("OnDiscreteCollision", colliders[i], SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}