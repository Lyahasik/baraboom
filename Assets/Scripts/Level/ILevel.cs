using UnityEngine;

namespace Baraboom.Level
{
	public interface ILevel
	{
		public Block GetTopBlock(Vector2Int cellPosition);
	}
}