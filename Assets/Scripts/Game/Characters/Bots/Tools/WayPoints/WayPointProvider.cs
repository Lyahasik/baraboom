using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Baraboom.Game.Characters.Bots.Tools
{
	public class WayPointProvider : MonoBehaviour
	{
		#region facade

		public IEnumerable<WayPoint> GetWayPoints(int botId)
		{
			if (botId == -1)
				throw new ArgumentException("Invalid bot ID.");

			if (!_wayPointsSorted.TryGetValue(botId, out var result))
				throw new ArgumentException($"Way points for bot with ID {botId} not found.");

			return result;
		}

		#endregion

		#region interior

		private Dictionary<int, WayPoint[]> _wayPointsSorted;

		[Inject]
		private void Initialize(WayPoint[] wayPoints)
		{
			_wayPointsSorted = wayPoints.GroupBy(wayPoint => wayPoint.BotId)
			                            .ToDictionary(grouping => grouping.Key, grouping => grouping.ToArray());
		}

		#endregion
	}
}