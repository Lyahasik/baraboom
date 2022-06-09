using System.Collections.Generic;
using UnityEngine;

namespace Baraboom.Game.Bots.States
{
	public interface IControllableBot
	{
		Vector2Int Position { get; }

		bool IsMoving { get; }

		void Move(IEnumerable<Vector2Int> path);
	}
}