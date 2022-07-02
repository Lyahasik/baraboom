using UnityEngine;
using UnityEngine.EventSystems;

namespace Baraboom.Game.UI
{
	public class TouchController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
	{
		#region facade

		public Vector2Int Drag => _lastDelta;

		public bool Click => _hasClick;

		void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
		{
			_isDragging = true;
			_canClick = true;
			_fixedDirection = DetermineDirection(eventData.delta);
		}

		void IEndDragHandler.OnEndDrag(PointerEventData eventData)
		{
			_isDragging = false;
			_canClick = true;
			_fixedDirection = null;
			_lastDelta = Vector2Int.zero;
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
			_canClick = false;

			if (!_isDragging)
				return;
			if (_fixedDirection == null)
				return;

			var currentDirection = DetermineDirection(eventData.delta);
			var deltaMagnitude = eventData.delta.magnitude;

			if (currentDirection == _fixedDirection)
			{
				_lastDelta = _fixedDirection.Value.ToVector();
			}
			else if (deltaMagnitude > _offCourseTolerance)
			{
				_lastDelta = Vector2Int.zero;
				_isDragging = false;
			}
		}

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
		{
			if (_canClick)
				_hasClick = true;
		}

		#endregion

		#region interior

		[SerializeField] private float _offCourseTolerance;

		private bool _isDragging;
		private bool _canClick;
		private Direction? _fixedDirection;
		private Vector2Int _lastDelta;
		private bool _hasClick;

		private void Awake()
		{
			_canClick = true;
		}

		private void LateUpdate()
		{
			_hasClick = false;
		}

		private static Direction DetermineDirection(Vector2 delta)
		{
			if (Vector2.Angle(delta, Vector2.right) is (>= -45 and < +45) or (>= 135 and < 225))
				return new Direction(Axis.X, SignTools.DetermineSign(delta.x));
			else
				return new Direction(Axis.Y, SignTools.DetermineSign(delta.y));
		}

		#endregion
	}
}