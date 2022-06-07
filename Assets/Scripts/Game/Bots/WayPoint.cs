using Baraboom.Game.Tools;
using Baraboom.Game.Tools.Extensions;
using UnityEngine;

namespace Baraboom.Game.Bots
{
	[RequireComponent(typeof(DiscreteTransform))]
	public sealed class WayPoint : MonoBehaviour
	{
		#region facade

		public Vector2Int Position => _discreteTransform.DiscretePosition.Make2D();
		
		#endregion

		#region interior

		private DiscreteTransform _discreteTransform;

		private void Awake()
		{
			_discreteTransform = GetComponent<DiscreteTransform>();
		}

		#endregion
	}
}