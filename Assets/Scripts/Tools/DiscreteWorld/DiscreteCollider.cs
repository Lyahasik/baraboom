using System;
using UnityEngine;

namespace Tools
{
	[RequireComponent(typeof(DiscreteTransform))]
	public class DiscreteCollider : MonoBehaviour
	{
		#region facade

		public event Action Destroyed;

		public virtual void OnCollision(DiscreteCollider other)
		{}

		#endregion
		
		#region interior

		protected virtual void Awake()
		{
			var discreteCollisionDetector = GameObject.Find("DiscreteCollisionDetector").GetComponent<DiscreteCollisionDetector>(); // TODO Inject
			discreteCollisionDetector.RegisterCollider(this);
		}

		private void OnDestroy()
		{
			Destroyed?.Invoke();
		}

		#endregion
	}
}