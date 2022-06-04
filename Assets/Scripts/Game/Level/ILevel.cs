using UnityEngine;

namespace Baraboom.Game.Level
{
	public interface ILevel
	{
		public Block GetTopBlock(Vector2Int cellPosition);
	}
}