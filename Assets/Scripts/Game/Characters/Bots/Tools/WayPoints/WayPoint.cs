using Baraboom.Game.Tools;
using Baraboom.Game.Tools.Extensions;
using UnityEngine;

namespace Baraboom.Game.Characters.Bots.Tools
{
	[RequireComponent(typeof(DiscreteTransform))]
	public sealed class WayPoint : MonoBehaviour
	{
		#region facade

		public Vector2Int Position => _discreteTransform.DiscretePosition.XY();

		public int BotId => _botId;

		#endregion

		#region interior

		[SerializeField] private int _botId = -1;

		private DiscreteTransform _discreteTransform;

		private void Awake()
		{
			_discreteTransform = GetComponent<DiscreteTransform>();
		}

		#endregion
	}
}