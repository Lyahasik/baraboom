using System;
using UnityEngine;

namespace Baraboom.Game.Tools.DiscreteWorld
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Transform))]
	public class DiscreteTransform : MonoBehaviour
	{
		#region facade

		public event Action DiscretePositionChanging;

		public event Action DiscretePositionChanged;

		public Vector3Int DiscretePosition
		{
			get
			{
				InitializeIfNeeded();
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

		private bool _isInitialized;

		private void Awake()
		{
			InitializeIfNeeded();
		}

		private void Update()
		{
			CheckPositionChange();
		}

		private void InitializeIfNeeded()
		{
			if (!_isInitialized)
				_discretePosition = DiscreteTranslator.ToDiscrete(transform.position);

			_isInitialized = true;
		}

		private void CheckPositionChange()
		{
			if (!transform.hasChanged)
				return;

			var newDiscretePosition = DiscreteTranslator.ToDiscrete(transform.position);
			if (newDiscretePosition == _discretePosition)
				return;

			DiscretePositionChanging?.Invoke();
			_discretePosition = newDiscretePosition;
			DiscretePositionChanged?.Invoke();

			transform.hasChanged = false;
		}

		#endregion
	}
}