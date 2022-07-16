using Baraboom.Game.Characters.Bots.Tools.Navigation;
using UnityEngine;

namespace Baraboom.Game.Characters.Bots.Protocols
{
	public interface IBotPathFinder
	{
		Path FindPath(Vector3Int start, Vector3Int target);
	}
}