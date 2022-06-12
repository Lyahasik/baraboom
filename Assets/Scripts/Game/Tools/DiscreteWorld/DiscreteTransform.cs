using System;
using UnityEngine;

namespace Baraboom.Game.Tools
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Transform))]
	public class DiscreteTransform : MonoBehaviour
	{
		#region facade

		public event Action DiscretePositionChanged;

		public Vector3Int DiscretePosition
		{
			get
			{
				return _discretePosition;
			}
			set
			{
				_discretePosition = value;
				transform.position = DiscreteTranslator.ToContinuous(_discretePosition);
			}
		}

		#endregion

		#region interior

		[SerializeField] private Vector3Int _discretePosition;

		private bool _discretePositionDirty;

		private void Awake()
		{
			_discretePosition = DiscreteTranslator.ToDiscrete(transform.position);
		}

		private void Update()
		{
			CheckPositionChange();
		}

		private void CheckPositionChange()
		{
			if (!transform.hasChanged)
				return;

			var newDiscretePosition = DiscreteTranslator.ToDiscrete(transform.position);
			if (newDiscretePosition == _discretePosition)
				return;

			_discretePosition = newDiscretePosition;
			DiscretePositionChanged?.Invoke();

			transform.hasChanged = false;
		}

		#endregion
	}
}