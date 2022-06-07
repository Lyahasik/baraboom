using UnityEngine;

namespace Baraboom.Game.Tools
{
	[ExecuteInEditMode]
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

		private void Awake()
		{
			FetchDiscretePosition();
		}

		private void Update()
		{
			if (transform.hasChanged)
			{
				FetchDiscretePosition();
				transform.hasChanged = false;
			}
		}

		private void FetchDiscretePosition()
		{
			_discretePosition = DiscreteTranslator.ToDiscrete(transform.position);
		}

		#endregion
	}
}