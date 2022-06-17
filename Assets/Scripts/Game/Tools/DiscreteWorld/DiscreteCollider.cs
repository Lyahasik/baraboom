using System;
using UnityEngine;

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

		private void Awake()
		{
			Transform = GetComponent<DiscreteTransform>();

			var discreteColliderRegistry = GameObject.Find("DiscreteColliderRegistry").GetComponent<DiscreteColliderRegistry>(); // TODO Inject
			discreteColliderRegistry.RegisterCollider(this);
		}

		private void OnDestroy()
		{
			Destroyed?.Invoke();
		}

		#endregion
	}
}