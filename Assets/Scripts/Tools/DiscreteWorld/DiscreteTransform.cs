using UnityEngine;

namespace Tools
{
	[RequireComponent(typeof(Transform))]
	public class DiscreteTransform : MonoBehaviour
	{
		#region facade

		public Vector3Int DiscretePosition
		{
			get => _discretePosition;
			set
			{
				_discretePosition = value;
				transform.position = DiscreteTranslator.ToContinuous(_discretePosition);
			}
		}

		#endregion

		#region interior

		[SerializeField] private Vector3Int _discretePosition;

		private void Update()
		{
			if (transform.hasChanged)
			{
				_discretePosition = DiscreteTranslator.ToDiscrete(transform.position);
				transform.hasChanged = false;
			}
		}

		#endregion
	}
}