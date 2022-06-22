using UnityEngine;
using Zenject;

namespace Baraboom.Game.Tools.DiscreteWorld
{
	[RequireComponent(typeof(DiscreteTransform))]
	public sealed class DiscreteCollider : VerboseBehaviour
	{
		#region facade

		public DiscreteTransform Transform { get; private set; }

		#endregion

		#region interior

		[Inject] private DiscreteColliderRegistry _colliderRegistry;

		private void Awake()
		{
			Transform = GetComponent<DiscreteTransform>();
			_colliderRegistry.RegisterCollider(this);
		}

		#endregion
	}
}