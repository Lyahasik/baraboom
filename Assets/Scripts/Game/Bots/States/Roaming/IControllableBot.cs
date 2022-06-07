using System.Collections.Generic;
using UnityEngine;

namespace Baraboom.Game.Bots.States
{
	public interface IControllableBot
	{
		WayPoint[] WayPoints { get; }
	
		Vector2Int Position { get; }

		bool IsMoving { get; }

		void MoveAlongPath(IEnumerable<Vector2Int> path);
	}
}