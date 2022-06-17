using Baraboom.Game.Tools.DiscreteWorld;
using UnityEngine;

namespace Baraboom.Game.Characters.Bots.Tools
{
	[RequireComponent(typeof(DiscreteTransform))]
	public sealed class WayPoint : MonoBehaviour
	{
		#region facade

		public Vector3Int Position => _discreteTransform.DiscretePosition;

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