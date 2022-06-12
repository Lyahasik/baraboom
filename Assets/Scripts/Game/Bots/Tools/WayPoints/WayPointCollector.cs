using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Baraboom.Game.Bots.Tools
{
	public static class WayPointCollector
	{
		public static IEnumerable<WayPoint> Collect(int botId)
		{
			if (botId == -1)
				throw new ArgumentException("Invalid bot ID");

			// TODO Inject?
			return GameObject.FindGameObjectsWithTag("WayPoint")
			                 .Select(@object => @object.GetComponent<WayPoint>())
			                 .Where(wayPoint => wayPoint != null && wayPoint.BotId == botId);
		}
	}
}