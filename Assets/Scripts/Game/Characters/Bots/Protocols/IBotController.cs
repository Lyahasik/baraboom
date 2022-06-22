using System.Collections.Generic;
using UnityEngine;

namespace Baraboom.Game.Characters.Bots.Protocols
{
	public interface IBotController
	{
		Vector3Int Position { get; }

		bool IsMoving { get; }

		void Move(IEnumerable<Vector2Int> path);

		void RequestStop();
	}
}