using System;
using UnityEngine;
using Zenject;

namespace Baraboom.Game.Tools.DiscreteWorld
{
	[RequireComponent(typeof(DiscreteTransform))]
	public sealed class DiscreteCollider : MonoBehaviour
	{
		#region facade

		public DiscreteTransform Transform { get; private set; }

		public event Action Destroyed;

		#endregion

		#region interior

		[Inject] private DiscreteColliderRegistry _colliderRegistry;

		private void Awake()
		{
			Transform = GetComponent<DiscreteTransform>();
			_colliderRegistry.RegisterCollider(this);
		}

		private void OnDestroy()
		{
			Destroyed?.Invoke();
		}

		#endregion
	}
}